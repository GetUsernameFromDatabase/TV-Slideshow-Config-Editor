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
    }
}
