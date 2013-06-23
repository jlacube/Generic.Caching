using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Generic.Caching
{
    interface IObjectProvider<TType>
    {
        TType GetItem(string key);
        event EventHandler OnUpdate;
    }
}
