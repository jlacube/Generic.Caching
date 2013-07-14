using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using Generic.Caching.Interfaces;

namespace Generic.Caching
{
    public class Cache<TType> : ICache<TType>, IDisposable
    {
		private readonly ReaderWriterLock cacheLock = new ReaderWriterLock();
		private readonly ReaderWriterLock evictionLock = new ReaderWriterLock();
		private readonly Hashtable internalCache = new Hashtable();
		private readonly Dictionary<EvictionPriority,List<CacheItem<TType>>> evictionBuckets = new Dictionary<EvictionPriority, List<CacheItem<TType>>> ();

		protected bool running;

		Timer expirationTimer;

		private object workerThreadsSyncObj = new object ();
		protected List<Thread> workerThreads = new List<Thread>();

		protected void AddWorkerThread(Thread thread)
		{
			lock (workerThreadsSyncObj) {
				if (!workerThreads.Contains(thread))
					workerThreads.Add (thread);
			}
		}

		protected void RemoveWorkerThread(Thread thread)
		{
			lock (workerThreadsSyncObj) {
				if (workerThreads.Contains (thread))
					workerThreads.Remove (thread);
			}
		}

		#region Constructors

		public Cache()
		{
			evictionBuckets.Add (EvictionPriority.Highest, new List<CacheItem<TType>> ());
			evictionBuckets.Add (EvictionPriority.Higher, new List<CacheItem<TType>> ());
			evictionBuckets.Add (EvictionPriority.High, new List<CacheItem<TType>> ());
			evictionBuckets.Add (EvictionPriority.Medium, new List<CacheItem<TType>> ());
			evictionBuckets.Add (EvictionPriority.Low, new List<CacheItem<TType>> ());
			evictionBuckets.Add (EvictionPriority.Lower, new List<CacheItem<TType>> ());
			evictionBuckets.Add (EvictionPriority.Lowest, new List<CacheItem<TType>> ());
			evictionBuckets.Add (EvictionPriority.Never, new List<CacheItem<TType>> ());

			running = true;

			Thread.CurrentThread.Priority = ThreadPriority.Highest;

			expirationTimer = new Timer(new TimerCallback(ExpirationTask), running, 0, 1000);
		}

		#endregion

		#region ExpirationTask & Timer utilities

		class ExpirationStateObject
		{
			public readonly object expirationTaskSyncObj = new object();
			public bool expirationTaskAlreadyRunning = false;
		}

		private void ExpirationTask(object state)
		{
			ExpirationStateObject stateObj = (ExpirationStateObject)state;

			if (stateObj.expirationTaskAlreadyRunning)
				return;

			lock (stateObj.expirationTaskSyncObj) {
				if (stateObj.expirationTaskAlreadyRunning)
					return;

				stateObj.expirationTaskAlreadyRunning = true;
			}

			cacheLock.AcquireWriterLock (-1);
			evictionLock.AcquireWriterLock (-1);

			try{
				List<Thread> evictionThreads = new List<Thread>();

				EvictionPriority[] priorities = evictionBuckets.Keys.ToArray();
				Array.Sort (priorities, new Comparison<EvictionPriority>((x,y) => { return ((int)x).CompareTo((int)y); }));

				foreach (EvictionPriority priority in priorities) {
					Thread evictionThread = new Thread(new ParameterizedThreadStart(ExpirationTaskForEvictionPriority));
					evictionThreads.Add(evictionThread);
					evictionThread.Start(evictionBuckets[priority]);
				}

				foreach (Thread evictionThread in evictionThreads) {
					evictionThread.Join();
				}

				evictionThreads.Clear();

			} finally {
				cacheLock.ReleaseWriterLock ();
				evictionLock.ReleaseWriterLock ();
			}

			lock (stateObj.expirationTaskSyncObj) {
				stateObj.expirationTaskAlreadyRunning = false;
			}
		}

		private void ExpirationTaskForEvictionPriority(object obj)
		{
			List<CacheItem<TType>> items = (List<CacheItem<TType>>) obj;

			foreach (CacheItem<TType> item in items) {
				internalCache.Remove(item.Key);
			}

			items.Clear ();
		}

		#endregion

		#region ICache Events implementation

		event EventHandler ItemAdded;
		event EventHandler ItemRemoved;
		event EventHandler ItemChanged;

		event EventHandler ICache<TType>.ItemAdded {
			add {
				lock (ItemAdded)
				{
					ItemAdded += value;
				}
			}
			remove {
				lock (ItemAdded)
				{
					ItemAdded -= value;
				}
			}
		}

		event EventHandler ICache<TType>.ItemRemoved {
			add {
				lock (ItemRemoved)
				{
					ItemRemoved += value;
				}
			}
			remove {
				lock (ItemRemoved)
				{
					ItemRemoved -= value;
				}
			}
		}

		event EventHandler ICache<TType>.ItemChanged {
			add {
				lock (ItemChanged)
				{
					ItemChanged += value;
				}
			}
			remove {
				lock (ItemChanged)
				{
					ItemChanged -= value;
				}
			}
		}

		protected virtual void OnItemAdded(CacheEventArgs<TType> e)
		{
			if (ItemAdded != null)
				ItemAdded (this, e);
		}

		protected virtual void OnItemRemoved(CacheEventArgs<TType> e)
		{
			if (ItemRemoved != null)
				ItemRemoved (this, e);
		}

		protected virtual void OnItemChanged(CacheEventArgs<TType> e)
		{
			if (ItemChanged != null)
				ItemChanged (this, e);
		}

		#endregion

		#region ICache implementation

		CacheItem<TType> ICache<TType>.GetCacheItem(string key)
		{
			cacheLock.AcquireReaderLock (-1);

			try
			{
				return (CacheItem<TType>)internalCache[key];
			}
			catch
			{
				return null;
			}
			finally
			{
				cacheLock.ReleaseReaderLock ();
			}
		}

		TType ICache<TType>.Get(string key)
        {
			CacheItem<TType> cacheItem = ((ICache<TType>)this).GetCacheItem (key);

			return cacheItem !=null ? cacheItem.Value : default(TType);
        }

		bool ICache<TType>.Contains(string key)
        {
			cacheLock.AcquireReaderLock (-1);

			try
			{
				return internalCache.ContainsKey(key);
			}
			finally
			{
				cacheLock.ReleaseReaderLock ();
			}
        }

		void ICache<TType>.Remove(string key)
        {
			cacheLock.AcquireReaderLock (-1);

			bool wasRemoved = false;
			CacheItem<TType> item = null;

			try
			{
				if (internalCache.ContainsKey(key))
				{
					LockCookie cookie = cacheLock.UpgradeToWriterLock(-1);
					item = (CacheItem<TType>)internalCache[key];
					internalCache.Remove(key);
					cacheLock.DowngradeFromWriterLock(ref cookie);
				}
			}
			finally
			{
				cacheLock.ReleaseReaderLock ();
			}

			if (wasRemoved) {
				evictionLock.AcquireWriterLock(-1);

				try{
					evictionBuckets[item.EvictionPriority].Remove(item);
				} finally {
					evictionLock.ReleaseWriterLock ();
				}
			}
        }

		void ICache<TType>.Add(string key, TType value)
		{
			((ICache<TType>)this).Add(key, new CacheItem<TType>(key, value));
		}

		void ICache<TType>.Add(string key, CacheItem<TType> cacheItem)
		{
			cacheLock.AcquireWriterLock (-1);

			try{
				internalCache.Add(key, cacheItem);
			} finally {
				cacheLock.ReleaseWriterLock ();
			}

			evictionLock.AcquireWriterLock (-1);

			try{
				evictionBuckets[cacheItem.EvictionPriority].Add(cacheItem);
			} finally {
				evictionLock.ReleaseWriterLock ();
			}
		}

		void ICache<TType>.Flush()
		{
			cacheLock.AcquireWriterLock (-1);

			try{
				internalCache.Clear();
			} finally {
				cacheLock.ReleaseWriterLock ();
			}

			evictionLock.AcquireWriterLock (-1);

			try{
				evictionBuckets[EvictionPriority.Highest].Clear();
				evictionBuckets[EvictionPriority.Higher].Clear();
				evictionBuckets[EvictionPriority.High].Clear();
				evictionBuckets[EvictionPriority.Medium].Clear();
				evictionBuckets[EvictionPriority.Low].Clear();
				evictionBuckets[EvictionPriority.Lower].Clear();
				evictionBuckets[EvictionPriority.Lowest].Clear();
				evictionBuckets[EvictionPriority.Never].Clear();
			} finally {
				evictionLock.ReleaseWriterLock ();
			}
		}

		#endregion

		#region IDisposable implementation

		private void safeStopWorkerThread(Thread thread)
		{
			if (thread.Join (500)) {
				if (!thread.Join (1000)) {
					try
					{
						thread.Abort();
					}
					catch {}
				}
			}
		}

		public void Dispose()
		{
			running = false;

			lock (workerThreadsSyncObj) {
				foreach (Thread thread in workerThreads) {
					safeStopWorkerThread (thread);
				}
			}

			expirationTimer.Dispose();
		}

		#endregion
    }
}
