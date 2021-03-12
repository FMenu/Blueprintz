using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprintz
{
    public static class Utils
    {
        public static string MiddleShortenTo(int caracters, string text)
        {
            if (text.Length > caracters)
                return text.Substring(0, caracters - 3) +
                    "..." + text.Substring(text.Length - 3, 3);
            else return text;
        }

        public static string ShortenTo(int caracters, string text)
        {
            if (text.Length > caracters)
                return text.Substring(0, caracters - 3) + "...";
            else return text;
        }

        public static Size DivideSize(Size arg1, int divider) =>
            new Size(arg1.Width / divider, arg1.Height / divider);

        public static Size SubstractSize(Size arg1, Size arg2) =>
            new Size(arg1.Width - arg2.Width, arg1.Height - arg2.Height);

        public static GarbageCollector GarbageCollection { get; } = new GarbageCollector();

        public class GarbageCollector
        {
            public GarbageCollector() { }
            public static void Collect()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
