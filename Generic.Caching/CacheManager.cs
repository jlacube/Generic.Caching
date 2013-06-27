using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Generic.Caching
{
    public class CacheManager : ICacheManager
    {
        ICache<TType> ICacheManager.InitializeCache<TType, TProvider>(TProvider objectProvider)
        {
            return null;
        }

        ICache<TType> ICacheManager.InitializeCache<TType>()
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
