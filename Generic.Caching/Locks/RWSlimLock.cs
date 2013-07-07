using System;
using System.Threading;

namespace Generic.Caching.Locks
{
	public class RWSlimLock : ILock
	{
		private ReaderWriterLockSlim internalLock = new ReaderWriterLockSlim ();

		#region ILock implementation

		void ILock.EnterUpgradeableReaderLock ()
		{
			internalLock.EnterUpgradeableReadLock ();
		}

		void ILock.UpgradeToWriterLock ()
		{
			internalLock.EnterWriteLock ();
		}

		void ILock.ExitUpgradeableReaderLock ()
		{
			internalLock.ExitUpgradeableReadLock ();
		}

		void ILock.EnterReaderLock ()
		{
			internalLock.EnterReadLock ();
		}

		void ILock.ExitReaderLock ()
		{
			internalLock.ExitReadLock ();
		}

		void ILock.EnterWriterLock ()
		{
			internalLock.EnterWriteLock ();
		}

		void ILock.ExitWriterLock ()
		{
			internalLock.ExitWriteLock ();
		}

		#endregion
	}
}

