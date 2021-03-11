using Blueprintz.Properties;
using Blueprintz.Style;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
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

        public const float mapSizeX = 4f;

        public EditorCanvas(PictureBox pb, MaterialTabControl tabC)
        {
            canvas = pb;
            tabs = tabC;
            uuip = GetUnityUnitAsPixels(mapSizeX, canvas.Width);
            canvas.MouseWheel += Canvas_MouseWheel;
            bitmap = new Bitmap(canvas.Image);
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

        public void Zoom(float zoomFactor)
        {
            // Ajust uuip
            uuip *= zoomFactor;

            // create image reference
            Image img = bitmap;

            // Create temporary bitmap
            Bitmap tempBitmap = new Bitmap(img.Width, img.Height);

            // Calculate bounds
            float width = img.Width * zoomFactor;
            float height = img.Height * zoomFactor;
            float x = img.Width / 2 - width / 2;
            float y = img.Height / 2 - height / 2;
            RectangleF desRect = new RectangleF(x, y, width, height);
            RectangleF scrRect = new RectangleF(0, 0, img.Width, img.Height);

            // Resize image
            Graphics graphics = Graphics.FromImage(tempBitmap);
            graphics.DrawImage(img, desRect, scrRect, GraphicsUnit.Pixel);
            graphics.Dispose();

            // Apply image
            canvas.Image = tempBitmap;
        }
    }
}
