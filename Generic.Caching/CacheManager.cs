using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Generic.Caching
{
    public class CacheManager : ICacheManager
    {
        public ICache ICacheManager.InitializeCache<TType, TProvider>(TProvider objectProvider)
        {
            return null;
        }

        public ICache ICacheManager.InitializeCache<TType>()
        {
            return null;
        }

        //private IObjectProvider<TType> objectProvider;
        //private ManualResetEvent evt = new ManualResetEvent(false);

        //public CacheManager(TProvider objectProvider)
        //{
        //    this.objectProvider = objectProvider;
        //}

        //public TType GetItem(string key)
        //{
        //    return objectProvider.GetItem(key);
        //}
    }
}
