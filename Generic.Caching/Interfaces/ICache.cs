using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generic.Caching.Interfaces;

namespace Generic.Caching.Interfaces
{
    public interface ICache<TType>
    {
        TType Get(string key);
		CacheItem<TType> GetCacheItem(string key);
        bool Contains(string key);
        void Remove(string key);
		void Add(string key, TType value);
        void Add(string key, CacheItem<TType> item);
		void Flush();
		event EventHandler ItemAdded;
		event EventHandler ItemRemoved;
		event EventHandler ItemChanged;
    }

	public class CacheEventArgs<TType> : EventArgs
	{
		private string key;
		private TType value;
		private TType newValue;

		public CacheEventArgs(string key, TType value, TType newValue)
		{
			this.key = key;
			this.value = value;
			this.newValue = newValue;
		}

		string Key { get { return key; } }
		TType Value { get { return value; } }
		TType NewValue { get { return newValue; } }
	}

    public interface ICacheWithProvider<TType, TProvider> : ICache<TType> where TProvider : IObjectProvider<TType>
    {
		void Load(string key);
		void Load(string key, ICacheItemExpiration[] expirations);
		void Load(string key, ICacheItemRefreshAction<TType> refreshAction);
		void Load(string key, ICacheItemExpiration[] expirations, ICacheItemRefreshAction<TType> refreshAction);

        TProvider ObjectProvider { get; set; }
    }
}
