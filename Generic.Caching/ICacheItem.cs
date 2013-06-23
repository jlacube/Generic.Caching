using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Generic.Caching
{
    enum EvictionPriority { Lowest, Lower, Low, Medium = 0, High, Higher, Highest };

    enum ExpirationType { AbsoluteExpiration, SlidingExpiration };

    interface ICacheItem<TType>
    {
        string Key { get; }
        TType Value { get; set; }
        string Region { get; set; }
    }

    public delegate void UpdatedEventHandler(object sender, EventArgs evt);

    interface ICacheItemWithProvider<TType> : ICacheItem<TType>
    {
        ManualResetEvent DataAvailable { get; }
        event UpdatedEventHandler OnUpdate;
    }
}
