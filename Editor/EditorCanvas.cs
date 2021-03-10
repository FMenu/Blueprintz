using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Blueprintz.Editor
{
    public class EditorCanvas
    {
        private PictureBox canvas;
        private double uuip = 0;

        public const float mapSizeX = 4f;

        public EditorCanvas(PictureBox pb)
        {
            canvas = pb;
            uuip = GetUnityUnitAsPixels(mapSizeX, canvas.Width);
        }

        private double GetUnityUnitAsPixels(double mapSizeInUnityUnits, int imageSizeInPixels)
            => imageSizeInPixels / mapSizeInUnityUnits;

        public void Zoom(double zoomFactor)
        {
            uuip *= zoomFactor;
            
        }
    }
}
