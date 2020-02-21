using System;

namespace LoremNET
{
    internal static class Extensions
    {
        internal static string Remove(this string s, string pattern)
        {
            return s.Replace(pattern, "");
        }

        internal static string[] Split(this string s, string separator)
        {
            return s.Split(new[] { separator }, StringSplitOptions.None);
        }

        internal static string UppercaseFirst(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}