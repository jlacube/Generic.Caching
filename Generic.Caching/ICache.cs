using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic.Caching
{
    interface ICache
    {
        object Get(string key);
        object Get(string key, string region);
        bool Contains(string key);
        bool Contains(string key, string region);
        void Remove(string key);
        void Remove(string key, string region);
    }

    interface ICacheType<TType> : ICache
    {
        void Add(string key, TType item);
        void Add(string key, TType item, ICacheItemPolicy cacheItemPolicy);
        void Add(string key, string region, TType item);
        void Add(string key, string region, TType item, ICacheItemPolicy cacheItemPolicy);
        new TType Get(string key);
        new TType Get(string key, string region);
    }

    interface ICacheTypeWithProvider<TType, TProvider> : ICacheType<TType> where TProvider : IObjectProvider<TType>
    {
        TProvider ObjectProvider { get; set; }
    }
}
