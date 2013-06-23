using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic.Caching
{
    interface ICacheManager
    {
        ICache InitializeCache<TType, TProvider>(TProvider objectProvider);
        ICache InitializeCache<TType>();
    }
}
