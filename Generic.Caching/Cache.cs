using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

namespace Generic.Caching
{
    public class Cache<TType> : ICacheType<TType>
    {
		ReaderWriterLock cacheLock = new ReaderWriterLock();
		private Hashtable internalCache = new Hashtable();

		#region ICache implementation

		TType ICache<TType>.Get(string key)
        {
			cacheLock.AcquireReaderLock (-1);

			try
			{
				TType result = default(TType);
				result = (TType)internalCache[key];

				return result;
			}
			finally
			{
				cacheLock.ReleaseReaderLock ();
			}
        }

		bool ICache<TType>.Contains(string key)
        {
			cacheLock.AcquireReaderLock (-1);

			try
			{
				return internalCache.ContainsKey(key);
			}
			finally
			{
				cacheLock.ReleaseReaderLock ();
			}
        }

		void ICache<TType>.Remove(string key)
        {
			cacheLock.AcquireReaderLock (-1);
			bool modified = false;

			try
			{
				if (internalCache.ContainsKey(key))
				{
					LockCookie cookie = cacheLock.UpgradeToWriterLock(-1);
					modified = true;
					internalCache.Remove(key);
					cacheLock.DowngradeFromWriterLock(ref cookie);
				}
			}
			finally
			{
				if (modified)
					cacheLock.ReleaseReaderLock ();
				else
					cacheLock.ReleaseWriterLock();
			}
        }

		#endregion

		#region ICacheType implementation

		void ICacheType<TType>.Add (string key, TType item)
		{
			cacheLock.AcquireWriterLock (-1);

			try
			{
				internalCache.Add(key, item);
			}
			finally 
			{
				cacheLock.ReleaseWriterLock ();
			}
		}

		void ICacheType<TType>.Add (string key, TType item, ICacheItemPolicy cacheItemPolicy)
		{
			throw new NotImplementedException ();
		}

		#endregion
    }
}
