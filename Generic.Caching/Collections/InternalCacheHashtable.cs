using System;
using System.Collections;

namespace Generic.Caching.Collections
{
	public class InternalCacheHashtable : IInternalCache
	{
		private Hashtable internalCache = new Hashtable();

		#region IInternalCache implementation

		void IInternalCache.TryGetValue (string key, out object value)
		{
			value = internalCache[key];
		}

		void IInternalCache.Add(string key, object value)
		{
			internalCache.Add (key, value);
		}

		void IInternalCache.UpdateOrAdd(string key, object value)
		{
			internalCache [key] = value;
		}

		bool IInternalCache.Contains (string key)
		{
			return internalCache.ContainsKey (key);
		}

		bool IInternalCache.ContainsKey (string key)
		{
			return internalCache.ContainsKey(key);
		}

		int IInternalCache.Count
		{
			get { return internalCache.Count; }
		}

		void IInternalCache.Clear()
		{
			internalCache.Clear ();
		}

		void IInternalCache.Remove(string key)
		{
			internalCache.Remove (key);
		}

		#endregion
	}
}

