using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Generic.Caching
{
    public class Cache<TType> : ICache<TType>
    {
		ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
		private Dictionary<string,TType> internalCache = new Dictionary<string, TType>();

        public TType Get(string key)
        {
			cacheLock.EnterReadLock();

			try
			{
				TType result = default(TType);
				internalCache.TryGetValue(key, out result);

				return result;
			}
			finally
			{
				cacheLock.ExitReadLock();
			}
        }

        public TType Get(string key, string region)
        {
            throw new NotImplementedException();
        }


        public bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string key, string region)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key, string region)
        {
            throw new NotImplementedException();
        }
    }
}
