using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic.Caching
{
    interface ICache<TType>
    {
        TType Get(string key);
        TType Get(string key, string region);
        bool Contains(string key);
        bool Contains(string key, string region);
        void Remove(string key);
        void Remove(string key, string region);
    }

    interface ICacheType<TType> : ICache<TType>
    {
        void Add(string key, TType item);
        void Add(string key, TType item, ICacheItemPolicy cacheItemPolicy);
        void Add(string key, string region, TType item);
        void Add(string key, string region, TType item, ICacheItemPolicy cacheItemPolicy);
    }

    interface ICacheTypeWithProvider<TType, TProvider> : ICache<TType> where TProvider : IObjectProvider<TType>
    {
		void Load(string key);
		void Load(string key, ICacheItemPolicy cacheItemPolicy);
		void Load(string key, string region);
		void Load(string key, string region, ICacheItemPolicy cacheItemPolicy);

        TProvider ObjectProvider { get; set; }
    }
}
