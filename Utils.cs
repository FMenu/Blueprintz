using System;
using System.Collections.Generic;
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
    }
}
