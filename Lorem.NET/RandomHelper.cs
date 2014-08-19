using System;
using System.Threading;

namespace Lorem.NET
{
    /*
     * http://stackoverflow.com/a/1785821/234132
     */
    public static class RandomHelper
    {
        private static int seedCounter = new Random().Next();

        [ThreadStatic]
        private static Random rng;

        public static Random Instance
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