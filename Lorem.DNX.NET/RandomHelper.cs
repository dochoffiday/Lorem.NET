using System;
using System.Threading;

namespace LoremNET
{
    /// <summary>
    /// A thread-safe helper class to get an instance of Random.
    /// </summary>
    /// <remarks>
    /// From http://stackoverflow.com/a/1785821/234132
    /// </remarks>
    public static class RandomHelper
    {
        [ThreadStatic]
        private static Random _rng;

        /// <summary>
        /// The seed used for each instance of Random
        /// </summary>
        private static int _seedCounter = new Random().Next();

        /// <summary>
        /// Gets thread-local instance of Random.
        /// </summary>
        /// <value>
        /// An instance of Random, lazily implemented.
        /// </value>
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