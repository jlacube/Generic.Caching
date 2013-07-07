using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic.Caching
{
    public interface ICache<TType>
    {
        TType Get(string key);
        bool Contains(string key);
        void Remove(string key);
    }

    public interface ICacheType<TType> : ICache<TType>
    {
        void Add(string key, TType item);
        void Add(string key, TType item, ICacheItemPolicy cacheItemPolicy);
    }

    public interface ICacheTypeWithProvider<TType, TProvider> : ICache<TType> where TProvider : IObjectProvider<TType>
    {
		void Load(string key);
		void Load(string key, ICacheItemPolicy cacheItemPolicy);

        TProvider ObjectProvider { get; set; }
    }
}
