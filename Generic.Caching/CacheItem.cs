using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Generic.Caching.Interfaces;

namespace Generic.Caching
{
    public enum EvictionPriority { Never = int.MinValue, Lowest = -3, Lower = -2, Low = -1, Medium = 0, High = 1, Higher = 2, Highest = 3 };

    public class CacheItem<TType>
    {
		private string key;
		private TType value;
		private ICacheItemExpiration[] expirations;
		private EvictionPriority evictionPriority;
		private DateTime lastAccessedTime;

		public string Key { get { return key; } }
		public TType Value { get { /*lastAccessedTime = DateTime.Now.ToUniversalTime();*/ return value; } }
		public EvictionPriority EvictionPriority { get { return evictionPriority; } }
		public DateTime LastAccessedTime { get { return lastAccessedTime; } }

		public CacheItem(string key, TType value)
			: this(key, value, null, EvictionPriority.Never)
		{}

		public CacheItem(string key, TType value, ICacheItemExpiration[] expirations, EvictionPriority evictionPriority)
		{
			this.key = key;
			this.value = value;
			/*this.lastAccessedTime = DateTime.Now.ToUniversalTime();*/

			if (expirations != null) {
				this.expirations = new ICacheItemExpiration[0];
				this.evictionPriority = EvictionPriority.Never;
			} else {
				this.expirations = expirations;
				this.evictionPriority = evictionPriority;
			}
		}

		public bool EligibleForExpiration
		{
			get {
				foreach (var expiration in expirations) {
					if (expiration.HasExpired ())
						return true;
				}

				return false;
			}
		}
    }

    public class CacheItemWithProvider<TType> : CacheItem<TType>
    {
		private IObjectProvider<TType> objectProvider;
		private ICacheItemRefreshAction<TType> refreshAction;

		public IObjectProvider<TType> ObjectProvider { get { return objectProvider; } }
		public ICacheItemRefreshAction<TType> RefreshAction { get { return refreshAction; } }

		public CacheItemWithProvider(string key, TType value, IObjectProvider<TType> objectProvider)
			: base(key, value)
		{
			this.objectProvider = objectProvider;
		}

		public CacheItemWithProvider(string key, TType value, IObjectProvider<TType> objectProvider, ICacheItemExpiration[] expirations, EvictionPriority evictionPriority)
			: base(key, value, expirations, evictionPriority)
		{
			this.objectProvider = objectProvider;
		}

		public CacheItemWithProvider(string key, TType value, IObjectProvider<TType> objectProvider, ICacheItemExpiration[] expirations, EvictionPriority evictionPriority, ICacheItemRefreshAction<TType> refreshAction)
			: base(key, value, expirations, evictionPriority)
		{
			this.refreshAction = refreshAction;
		}
    }
}
