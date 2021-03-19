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

        private MouseButtons mouseButtons = MouseButtons.None;

        private Timer mouseUpdate = new Timer();

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

        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUpdate.Stop();
            mouseButtons = MouseButtons.None;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            mouseButtons = e.Button;
            if (mouseButtons == MouseButtons.Left)
                mouseUpdate.Start();
        }

        private void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (tabs.SelectedTab == Tabs.editorPage)
            {

            }
        }

        public void Dispose()
        {
            mouseUpdate.Dispose();
            canvas.Image.Dispose();
        }

        public Image TransformImage(Image img, RectangleF srcRect, RectangleF desRect)
        {
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);
            Graphics graphics = Graphics.FromImage(tempBitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel);
            graphics.Dispose();
            return tempBitmap;
        }
    }
}