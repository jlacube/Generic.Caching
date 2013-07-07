using System;

namespace Generic.Caching.Locks
{
	public interface ILock
	{
		void EnterUpgradeableReaderLock();
		void UpgradeToWriterLock ();
		void ExitUpgradeableReaderLock();
		void EnterReaderLock();
		void ExitReaderLock();
		void EnterWriterLock();
		void ExitWriterLock();
	}
}

