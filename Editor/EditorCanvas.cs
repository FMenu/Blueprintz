using Blueprintz.Debugging;
using Blueprintz.Style;
using JumpinFrog.Vectors;
using MaterialSkin.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Blueprintz.Editor
{
    public class EditorCanvas
    {
        private PictureBox canvas;
        private MaterialTabControl tabs;
        private double uuip = 0;
        private Bitmap bitmap;

        private float zoom = 1;
        private bool mouseGrabbing = false;
        private MouseButtons mouseButtons = MouseButtons.None;

        private Vector2 mouseDragPos = Vector2.zero;
        private Vector2 oldPos = Vector2.zero;
        private Vector2 offset = Vector2.zero;

        public const float mapSizeX = 4f;

        public EditorCanvas(PictureBox pb, MaterialTabControl tabC)
        {
            canvas = pb;
            tabs = tabC;
            uuip = GetUnityUnitAsPixels(mapSizeX, canvas.Width);

            // Events
            canvas.MouseWheel += Canvas_MouseWheel;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseUp += Canvas_MouseUp;
            canvas.MouseMove += Canvas_MouseMove;

            bitmap = new Bitmap(canvas.Image);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseGrabbing && mouseButtons == MouseButtons.Left)
            {

                // Calculate normalized Mouse Position
                mouseDragPos.x = (float)e.X / canvas.Size.Width;
                mouseDragPos.y = (float)e.Y / canvas.Size.Height;

                // Calculate direction
                Vector2 pos = new Vector2(e.X, e.Y);
                Vector2 dir = VectorMathUtils.DirectionFromPoints(oldPos, pos);
                offset -= dir;

                //Move Image
                Navigate(offset, zoom);

                // Output Mouse pos
                Blueprintz.logger.Info("X: " + offset.x + " Y: " + offset.y + "   " + e.X + " " + e.Y);

                // Update position
                oldPos = new Vector2(e.X, e.Y);
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouseButtons = MouseButtons.None;
            mouseGrabbing = false;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            offset = new Vector2((-e.X) + offset.x, (-e.Y) + offset.y);
            oldPos = Vector2.zero;
            mouseButtons = e.Button;
            mouseGrabbing = true;
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

            // create image reference
            Image img = bitmap;

            // Create temporary bitmap
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);

            // Calculate bounds
            Vector2 size = new Vector2(img.Width * zoomFactor, img.Height * zoomFactor);
            Vector2 pos = new Vector2(move.x, move.y);
            RectangleF desRect = new RectangleF(pos.x, pos.y, size.x, size.y);
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
            // Ajust uuip
            uuip *= zoomFactor;

            // create image reference
            Image img = bitmap;

            // Create temporary bitmap
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);

            // Calculate bounds
            Vector2 size = new Vector2(img.Width * zoomFactor, img.Height * zoomFactor);
            Vector2 pos = new Vector2(img.Width / 2 - size.x / 2, img.Height / 2 - size.y / 2);
            RectangleF desRect = new RectangleF(pos.x, pos.y, size.x, size.y);
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
    }
}
