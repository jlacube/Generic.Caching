using System;

namespace Generic.Caching.Collections
{
	public interface IInternalCache
	{
		void TryGetValue (string key, out object value);
		void Add (string key, object value);
		void UpdateOrAdd(string key, object value);
		bool Contains (string key);
		bool ContainsKey(string key);
		int Count { get;}
		void Clear();
		void Remove (string key);
	}
}

