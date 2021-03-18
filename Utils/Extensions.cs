using Blueprintz.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Blueprintz
{
    public static class MapExtensions
    {
        public static string ToDescriptionString(this Map val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public static class FireworkTypeExtensions
    {
        public static string ToDescriptionString(this FireworkType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string GetDisplayString(this FireworkType val)
        {
            string name = Enum.GetName(val.GetType(), val);
            string splitName = name.SplitPascalCase(" ").Trim();
            return splitName;
        }
    }

    public static class IEnumeratorExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
    }

    public static class StringExtensions
    {
        public static string SplitPascalCase(this string value, string insert)
        {
            Regex regex = new Regex("([A-Z]+(?=$|[A-Z][a-z])|[A-Z]?[a-z]+|[0-9]+)", RegexOptions.Compiled);
            return regex.Replace(value, insert + "$1");
        }
    }
}
