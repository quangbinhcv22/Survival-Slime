using System.Text.RegularExpressions;

namespace Plugins.QB_UI.Core
{
    public static class ConvertCase
    {
        public static string Pascal_ToSnake(this string input)
        {
            const string charPattern = @"[^a-zA-Z0-9]";
            input = Regex.Replace(input, charPattern, string.Empty);

            const string pattern = @"(?<!^)([A-Z])";
            return string.IsNullOrEmpty(input) ? string.Empty : Regex.Replace(input, pattern, "_$1").ToLower();
        }
    }
}