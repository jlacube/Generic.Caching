using System;
using System.Threading;

namespace Generic.Caching.Locks
{
	public class RWLock : ILock
	{
		private ReaderWriterLock internalLock = new ReaderWriterLock();

		#region ILock implementation

		void ILock.EnterUpgradeableReaderLock ()
		{
			internalLock.AcquireReaderLock (-1);
		}

		void ILock.UpgradeToWriterLock ()
		{
			internalLock.UpgradeToWriterLock (-1);
		}

		void ILock.ExitUpgradeableReaderLock ()
		{
			internalLock.ReleaseReaderLock ();
		}

		void ILock.EnterReaderLock ()
		{
			internalLock.AcquireReaderLock(-1);
		}

		void ILock.ExitReaderLock ()
		{
			internalLock.ReleaseReaderLock ();
		}

		void ILock.EnterWriterLock ()
		{
			internalLock.AcquireWriterLock (-1);
		}

		void ILock.ExitWriterLock ()
		{
			internalLock.ReleaseWriterLock ();
		}

		#endregion
	}
}

