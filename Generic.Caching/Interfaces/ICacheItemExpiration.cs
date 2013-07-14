using System;

namespace Generic.Caching.Interfaces
{
	public interface ICacheItemExpiration
	{
		/// <summary>
		///	Specifies if item has expired or not.
		/// </summary>
		/// <returns>Returns true if the item has expired, otherwise false.</returns>
		bool HasExpired();

		/// <summary>
		/// Called to tell the expiration that the CacheItem to which this expiration belongs has been touched by the user
		/// </summary>
		void Notify();

		/// <summary>
		/// Called to give the instance the opportunity to initialize itself from information contained in the CacheItem.
		/// </summary>
		/// <param name="owningCacheItem">CacheItem that owns this expiration object</param>
		void Initialize<TType>(CacheItem<TType> owningCacheItem);
	}
}

