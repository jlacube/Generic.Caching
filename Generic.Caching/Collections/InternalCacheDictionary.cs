using System;
using System.Collections.Generic;

namespace Generic.Caching.Collections
{
	public class InternalCacheDictionary : IInternalCache
	{
		private Dictionary<string,object> internalCache = new Dictionary<string, object>();

		#region IInternalCache implementation

		void IInternalCache.TryGetValue (string key, out object value)
		{
			internalCache.TryGetValue (key, out value);
		}

		void IInternalCache.Add (string key, object value)
		{
			internalCache.Add (key, value);
		}

		void IInternalCache.UpdateOrAdd (string key, object value)
		{
			internalCache [key] = value;
		}

		bool IInternalCache.Contains (string key)
		{
			return internalCache.ContainsKey (key);
		}

		bool IInternalCache.ContainsKey (string key)
		{
			return internalCache.ContainsKey (key);
		}

		void IInternalCache.Clear ()
		{
			internalCache.Clear ();
		}

		int IInternalCache.Count {
			get {
				return internalCache.Count;
			}
		}

		void IInternalCache.Remove(string key)
		{
			internalCache.Remove (key);
		}

		#endregion
	}
}

