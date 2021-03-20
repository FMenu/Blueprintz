using Blueprintz.Style;
using MaterialSkin.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Reflection;
using System.Windows.Forms;

namespace Blueprintz.Editor
{
    public class EditorCanvas : EventBus, IDisposable
    {
        private PictureBox canvas;
        private MaterialTabControl tabs;

        private Bitmap bitmap;

        private MouseButtons mouseButtons = MouseButtons.None;

        private RectangleF worldSpace = Rectangle.Empty;
        private RectangleF screenSpace = Rectangle.Empty;
        private Vector2 worldScreenOffset = Vector2.Zero;

        private Point startPan;
        private Point mousePos;

        private Point mousePosAfterZoom;

        private Vector2 scale = Vector2.One;

        private readonly Vector2 scrollSensitivity = Vector2.One;

        private Timer mouseUpdate = new Timer();

        public EditorCanvas(PictureBox pb, MaterialTabControl tabC)
        {
            canvas = pb;
            tabs = tabC;

            Subscribe();

            //Reset
            if (canvas.Image != null) canvas.Image.Dispose();
            canvas.Image = Utils.LoadResource<Bitmap>("editorBox.Image");
            bitmap = new Bitmap(canvas.Image);

            // Events
            canvas.MouseWheel += Canvas_MouseWheel;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseUp += Canvas_MouseUp;
            canvas.MouseMove += Canvas_MouseMove;

            //Setup
            mouseUpdate.Interval = 10;
            mouseUpdate.Tick += MouseUpdate_Tick;

            //Initial Values
            worldSpace.Width = canvas.Width;
            worldSpace.Height = canvas.Height;

            screenSpace.Width = canvas.Width;
            screenSpace.Height = canvas.Height;

            BeginUpdate();
        }

        public override void Update()
        {

        }

        private void MouseUpdate_Tick(object sender, EventArgs e)
        {
            Vector2 pan = Vector2.Zero;
            pan.X = mousePos.X - startPan.X;
            pan.Y = mousePos.Y - startPan.Y;
            UpdateImage(pan, scale);
            startPan = mousePos;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = new Point(e.X, e.Y);
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
            {
                mouseUpdate.Start();
                startPan = new Point(e.X, e.Y);
            }
        }

        private void Canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (tabs.SelectedTab == Tabs.editorPage)
            {
                if (e.Delta < 0) scale -= scrollSensitivity / 10;
                else if (e.Delta > 0) scale += scrollSensitivity / 10;

                if (scale.X >= 1 && scale.Y >= 1) UpdateImage(Vector2.Zero, scale);
                else scale = Vector2.One;
            }
        }

        public void Dispose()
        {
            canvas.MouseWheel -= Canvas_MouseWheel;
            canvas.MouseDown -= Canvas_MouseDown;
            canvas.MouseUp -= Canvas_MouseUp;
            canvas.MouseMove -= Canvas_MouseMove;
            mouseUpdate.Tick -= MouseUpdate_Tick;
            mouseUpdate.Dispose();
            canvas.Image.Dispose();
            bitmap.Dispose();
            tabs = null;
            canvas = null;
        }

        private Image TransformImage(Image img, RectangleF srcRect, RectangleF desRect)
        {
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);
            Graphics graphics = Graphics.FromImage(tempBitmap);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel);
            graphics.Dispose();
            return tempBitmap;
        }

        private void UpdateImage(Vector2 displacement, Vector2 scale)
        {
            worldScreenOffset += displacement;
            Image image = bitmap;
            RectangleF src = new RectangleF(0, 0, image.Size.Width, image.Size.Height);
            RectangleF des = new RectangleF(worldScreenOffset.X, worldScreenOffset.Y, image.Size.Width * scale.X, image.Size.Height * scale.Y);
            canvas.Image.Dispose();
            canvas.Image = TransformImage(image, src, des);
        }

        public override IEnumerator GetParams<T>()
        {
            yield break;
        }

        private Point WorldToScreen(Vector2 world, Vector2 scale)
        {
            int x = (int)((world.X - worldScreenOffset.X) * scale.X);
            int y = (int)((world.Y - worldScreenOffset.Y) * scale.Y);
            return new Point(x, y);
        }

        private Vector2 ScreenToWorld(Point screen, Vector2 scale)
        {
            float x = (screen.X / scale.X) - worldScreenOffset.Y;
            float y = (screen.Y / scale.Y) - worldScreenOffset.Y;
            return new Vector2(x, y);
        }
    }
}