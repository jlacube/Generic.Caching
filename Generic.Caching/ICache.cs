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
    }

    interface ICacheType<TType> : ICache
    {
        TType Get(string key);
        TType Get(string key, string region);
    }

    interface ICacheTypeProvider<TType, TProvider> : ICacheType<TType> where TProvider : IObjectProvider<TType>
    {
        TProvider ObjectProvider { get; set; }
    }
}
