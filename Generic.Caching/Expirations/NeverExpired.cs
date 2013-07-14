using System;
using Generic.Caching.Interfaces;

namespace Generic.Caching.Expirations
{
    /// <summary>
    /// This class reflects an expiration policy of never being expired.
    /// </summary>
    [Serializable]
    public class NeverExpired : ICacheItemExpiration
    {
        /// <summary>
        /// Always returns false
        /// </summary>
        /// <returns>False always</returns>
        public bool HasExpired()
        {
            return false;
        }

        /// <summary>
        /// Not used
        /// </summary>
        public void Notify()
        {
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="owningCacheItem">Not used</param>
		public void Initialize<TType>(CacheItem<TType> owningCacheItem)
        {
        }
    }
}
