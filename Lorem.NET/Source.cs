using System.Collections.Generic;
using System.Linq;

namespace Lorem.NET
{
    internal class Source
    {
        const string LoremIpsum = @"lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua, ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat, duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur, excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum,";

        internal static IEnumerable<string> Rearrange(string words)
        {
            return words.Split(" ").OrderBy(x => RandomHelper.Instance.Next());
        }

        internal static IEnumerable<string> WordList(bool includePuncation)
        {
            return includePuncation ? Rearrange(LoremIpsum) : Rearrange(LoremIpsum.Remove(","));
        }
    }
}
