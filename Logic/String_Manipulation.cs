using System;
using System.Text.RegularExpressions;

namespace TV_Slideshow_Config_Editor.Logic
{
    struct String_Manipulation
    {
        public static string SplitCamelCase(string str)
        {
            return Regex.Replace(
                Regex.Replace(
                    str,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
            );
        }

        public static string CamelCaseToNormal(string str)
        {
            var result = SplitCamelCase(str).ToString();
            result = System.Threading.Thread.CurrentThread
           .CurrentCulture.TextInfo.ToTitleCase(result.ToLower());
            return result;
        }

        public static string MakeControlTitle(int index, string afterIndex)
        {
            return string.Format("{0}. {1}", index + 1, afterIndex);
        }

        public static string ChangeTitleCount(string title, int newIndex)
        {
            var dotIndex = title.IndexOf('.');
            if (dotIndex == -1)
                throw new ArgumentException("Couldn't index dot in title",
                    nameof(dotIndex));
            var afterStart = dotIndex + 2;
            var afterCount = afterStart >= title.Length ? "" :
                title.Substring(afterStart);
            return MakeControlTitle(newIndex, afterCount);
        }
    }
}
