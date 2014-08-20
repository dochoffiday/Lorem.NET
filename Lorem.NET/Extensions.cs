using System;

namespace LoremNET
{
    internal static class Extensions
    {
        internal static String Remove(this string s, string pattern)
        {
            return s.Replace(pattern, "");
        }
        internal static String[] Split(this string s, string separator)
        {
            return s.Split(new[] { separator }, StringSplitOptions.None);
        }

        internal static string UppercaseFirst(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
