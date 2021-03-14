using Blueprintz.Style;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Blueprintz.Editor
{
    public class EditorCanvas : IDisposable
    {
        private PictureBox canvas;
        private MaterialTabControl tabs;
        private double uuip = 0;
        private Bitmap bitmap;

        private float zoom = 1;
        private bool mouseGrabbing = false;
        private MouseButtons mouseButtons = MouseButtons.None;

        private Vector2 mouseDragPos = Vector2.Zero;
        private Vector2 normalMousePos = Vector2.Zero;
        private Vector2 oldPos = Vector2.Zero;
        private Vector2 offset = Vector2.Zero;

        private Timer mouseUpdate = new Timer();

        public const float mapSizeX = 4f;

        public EditorCanvas(PictureBox pb, MaterialTabControl tabC)
        {
            canvas = pb;
            tabs = tabC;
            uuip = GetUnityUnitAsPixels(mapSizeX, canvas.Width);

            //Reset
            canvas.Image.Dispose();
            canvas.Image = Utils.LoadResource<Bitmap>("editorBox.Image");
            zoom = 1;

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

        private void MovePlane(Vector2 mousePos)
        {
            // Calculate direction
            Vector2 pos = new Vector2(mousePos.X, mousePos.Y);
            Vector2 dir = Utils.GetDirection(oldPos, pos);
            offset -= dir;

            //Move Image
            Navigate(offset, zoom);

            // Output Mouse pos
            Blueprintz.logger.Debug("X: " + offset.X + " Y: " + offset.Y + "   " + mousePos.X + " " + mousePos.Y);

            // Update position
            oldPos = new Vector2(mousePos.X, mousePos.Y);
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUpdate.Stop();
            mouseButtons = MouseButtons.None;
            mouseGrabbing = false;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            offset = new Vector2((-e.X) + offset.X, (-e.Y) + offset.Y);
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
                if (e.Delta < 0) zoom -= 0.1f;
                else if (e.Delta >= 0) zoom += 0.1f;
                if (zoom >= 1) Zoom(zoom);
                else
                {
                    zoom = 1;
                    Zoom(1);
                }
            }
        }

        private float GetUnityUnitAsPixels(float mapSizeInUnityUnits, int imageSizeInPixels)
            => imageSizeInPixels / mapSizeInUnityUnits;

        public void Navigate(Vector2 move, float zoomFactor)
        {
            // Create image reference
            Image img = bitmap;

            // Create temporary bitmap
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);

            // Calculate bounds
            Vector2 size = new Vector2(img.Width * zoomFactor, img.Height * zoomFactor);
            Vector2 pos = new Vector2(move.X, move.Y);
            RectangleF desRect = new RectangleF(pos.X, pos.Y, size.X, size.Y);
            RectangleF scrRect = new RectangleF(0, 0, img.Width, img.Height);

            // Resize image
            Graphics graphics = Graphics.FromImage(tempBitmap);
            graphics.DrawImage(img, desRect, scrRect, GraphicsUnit.Pixel);

            // Free memory
            graphics.Dispose();
            canvas.Image.Dispose();

            // Apply image
            canvas.Image = tempBitmap;
        }

        public void Zoom(float zoomFactor)
        {
            // Create image reference
            Image img = bitmap;

            // Create temporary bitmap
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);

            // Calculate bounds
            Vector2 size = new Vector2(img.Width * zoomFactor, img.Height * zoomFactor);
            Vector2 pos = new Vector2(0, 0);
            RectangleF desRect = new RectangleF(pos.X, pos.Y, size.X, size.Y);
            RectangleF scrRect = new RectangleF(0, 0, img.Width, img.Height);

            // Resize image
            Graphics graphics = Graphics.FromImage(tempBitmap);
            graphics.DrawImage(img, desRect, scrRect, GraphicsUnit.Pixel);

            // Free memory
            graphics.Dispose();
            canvas.Image.Dispose();

            // Apply image
            canvas.Image = tempBitmap;
        }

        public void Dispose()
        {
            mouseUpdate.Dispose();
            canvas.Image.Dispose();
        }
    }
}