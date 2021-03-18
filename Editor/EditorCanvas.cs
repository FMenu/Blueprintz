using Blueprintz.Style;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;

namespace Blueprintz.Editor
{
    public class EditorCanvas : IDisposable
    {
        private PictureBox canvas;
        private MaterialTabControl tabs;
        private Bitmap bitmap;

        private bool mouseGrabbing = false;
        private MouseButtons mouseButtons = MouseButtons.None;

        private Vector2 mouseDragPos = Vector2.Zero;
        private Vector2 normalMousePos = Vector2.Zero;
        private Vector2 oldPos = Vector2.Zero;
        private Vector2 offset = Vector2.Zero;
        private Vector2 zoom = Vector2.One;

        private readonly Vector2 zoomStep = Vector2.One;

        private Rectangle worldCoord = Rectangle.Empty;

        private Timer mouseUpdate = new Timer();

        public const float mapSizeX = 4f;

        public EditorCanvas(PictureBox pb, MaterialTabControl tabC)
        {
            canvas = pb;
            tabs = tabC;

            //Reset
            canvas.Image.Dispose();
            canvas.Image = Utils.LoadResource<Bitmap>("editorBox.Image");

            // Events
            canvas.MouseWheel += Canvas_MouseWheel;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseUp += Canvas_MouseUp;
            canvas.MouseMove += Canvas_MouseMove;

            //Setup
            bitmap = new Bitmap(canvas.Image);
            mouseUpdate.Interval = 10;
            mouseUpdate.Tick += MouseUpdate_Tick;
        }

        private void MouseUpdate_Tick(object sender, EventArgs e)
        {
            MovePlane(normalMousePos);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Calculate normalized Mouse Position
            mouseDragPos.X = (float)e.X / canvas.Size.Width;
            mouseDragPos.Y = (float)e.Y / canvas.Size.Height;

            normalMousePos = new Vector2(e.X, e.Y);
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUpdate.Stop();
            mouseButtons = MouseButtons.None;
            mouseGrabbing = false;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            Program.logger.Debug(offset.ToString() + ":  before reassigning.");
            offset = new Vector2((-e.X) + offset.X, (-e.Y) + offset.Y);
            Program.logger.Debug(offset.ToString() + ":  after reassigning.");
            oldPos = Vector2.Zero;
            mouseButtons = e.Button;
            mouseGrabbing = true;
            if (mouseGrabbing && mouseButtons == MouseButtons.Left)
                mouseUpdate.Start();
        }

        private void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (tabs.SelectedTab == Tabs.editorPage)
            {
                Point mousePos = new Point(e.X, e.Y);
                if (e.Delta < 0) zoom -= zoomStep / 25;
                else if (e.Delta > 0) zoom += zoomStep / 25;
                if (zoom.X >= 1 && zoom.Y >= 1) canvas.Image = ScaleImage(bitmap, zoom, mousePos);
                else zoom = Vector2.One;
            }
        }

        private void MovePlane(Vector2 mousePos)
        {
            Vector2 pos = new Vector2(mousePos.X, mousePos.Y);
            Vector2 dir = Utils.GetDirection(oldPos, pos);
            offset -= dir;
            canvas.Image = MoveImage(bitmap, offset, zoom);
            oldPos = new Vector2(mousePos.X, mousePos.Y);
            worldCoord = new Rectangle((int)offset.X, (int)offset.Y, bitmap.Width, bitmap.Height);
            //TODO: Remove this when you have used the zoom aswell.
            zoom = Vector2.One;

            // Output Mouse pos
            Program.logger.Debug(offset.ToString() + " " + mousePos.ToString() + " | " + worldCoord.ToString() + " | " + dir.ToString());
        }

        public Image MoveImage(Image img, Vector2 pos, Vector2 currentScale)
        {
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);
            //TODO: Put the zoom into the mix. (currentScale)
            Vector2 size = new Vector2(img.Size.Width, img.Size.Height);
            RectangleF desRect = new RectangleF(pos.X, pos.Y, size.X, size.Y);
            RectangleF scrRect = new RectangleF(0, 0, img.Size.Width, img.Height);
            Graphics graphics = Graphics.FromImage(tempBitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(img, desRect, scrRect, GraphicsUnit.Pixel);
            graphics.Dispose();
            canvas.Image.Dispose();
            return tempBitmap;
        }

        public Image ScaleImage(Image img, Vector2 scale, Point cursorPos)
        {
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);
            Vector2 size = new Vector2(img.Size.Width / scale.X, img.Size.Height / scale.Y);
            Vector2 pos = new Vector2(canvas.Size.Width / 2 - size.X / 2, canvas.Size.Height / 2 - size.Y / 2);
            RectangleF desRect = new RectangleF(0, 0, img.Size.Width, img.Size.Height);
            RectangleF scrRect = new RectangleF(-offset.X + pos.X, -offset.Y + pos.Y, size.X, size.Y);
            Graphics graphics = Graphics.FromImage(tempBitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(img, desRect, scrRect, GraphicsUnit.Pixel);
            graphics.Dispose();
            canvas.Image.Dispose();
            return tempBitmap;
        }

        public void Dispose()
        {
            mouseUpdate.Stop();
            mouseDragPos = Vector2.Zero;
            oldPos = Vector2.Zero;
            normalMousePos = Vector2.Zero;
            offset = Vector2.Zero;
            mouseUpdate.Dispose();
            canvas.Image.Dispose();
        }
    }
}