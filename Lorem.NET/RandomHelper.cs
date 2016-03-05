using System;
using System.Threading;

namespace LoremNET
{
    /*
     * http://stackoverflow.com/a/1785821/234132
     */
    public static class RandomHelper
    {
        private static int _seedCounter = new Random().Next();

        [ThreadStatic]
        private static Random _rng;

        public static Random Instance
        {
            get
            {
                if (_rng != null) return _rng;
                var seed = Interlocked.Increment(ref _seedCounter);
                _rng = new Random(seed);
                return _rng;
            }
        }
    }
}