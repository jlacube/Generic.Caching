using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Generic.Caching.Interfaces
{
    public interface IObjectProvider<TType>
    {
        TType LoadItem(string key);
    }
}
