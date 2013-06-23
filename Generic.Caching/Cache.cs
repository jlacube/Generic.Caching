using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic.Caching
{
    public class Cache : ICache
    {

        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public object Get(string key, string region)
        {
            throw new NotImplementedException();
        }


        public bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string key, string region)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key, string region)
        {
            throw new NotImplementedException();
        }
    }
}
