using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueprintz.Editor
{
    public class EditorCanvas
    {
        private PictureBox canvas;
        public EditorCanvas(PictureBox pb)
        {
            canvas = pb;
        }

        private int GetUnityUnitAsPixels(int mapSizeInUnityUnits, int imageSizeInPixels)
            => imageSizeInPixels / mapSizeInUnityUnits;
    }
}
