using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
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

        public static uint GetResource<T>(string name, out T resource)
        {
            ComponentResourceManager resources =
                new ComponentResourceManager(typeof(Blueprintz));
            var res = resources.GetObject(name);
            object @null = null;
            if (res != null)
            {
                Blueprintz.logger.Info(typeof(T).ToString() + " " + res.GetType().ToString());
                if (res.GetType() == typeof(T))
                {
                    resource = (T)res;
                    return 0;
                }
                else
                {
                    resource = (T)@null;
                    return 2;
                }
            }
            resource = (T)@null;
            return 1;
        }

        public static T LoadResource<T>(string name)
        {
            uint result = GetResource(name, out T res);
            if (result == 0) return res;
            else throw new Exception(
                "Failed to load resource editorBox.Image. Returned: "
                + result.GetType().Name + ": " + result.ToString()
            );
        }

        public static Vector2 GetDirection(Vector2 origin, Vector2 point)
        {
            float x = origin.X - point.X;
            float y = origin.Y - point.Y;
            return new Vector2(x, y);
        }
    }
}
