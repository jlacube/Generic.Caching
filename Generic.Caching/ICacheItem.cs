using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Generic.Caching
{
    interface ICacheItem<TType>
    {
        string Key { get; }
        TType Value { get; set; }
        string Region { get; set; }
        ManualResetEvent DataAvailable { get; }
    }
}
