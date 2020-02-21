using System;
using System.Threading;

namespace LoremNET
{
    /*
     * http://stackoverflow.com/a/1785821/234132
     */
    internal static class RandomHelper
    {
        private static int seedCounter = new Random().Next();

        [ThreadStatic]
        private static Random rng;

        internal static Random Instance
        {
            get
            {
                if (rng == null)
                {
                    int seed = Interlocked.Increment(ref seedCounter);
                    rng = new Random(seed);
                }
                return rng;
            }
        }
    }
}