using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using Generic.Caching;
using Generic.Caching.Interfaces;

namespace Generic.Caching.ConsoleTest
{
	class MainClass
	{        
		private static ICache<string> cache = new Cache<string>();
		private static string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";

		static string CreateRandomString(int passwordLength, int idx)
		{            
			char[] chars = new char[passwordLength];
			Random rd = new Random((int)DateTime.Now.Ticks + idx);

			for (int i = 0; i < passwordLength; i++)
			{
				chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
			}
			return new string(chars);
		}

		private static void CacheAccessTest()
		{
			int span = 5;
			string key;
			string data;
			int itens = 1000;
			int interactions = 1000000;
			int cont = 0;
			int index = 0;
			List<string> keys = new List<string>();

			cont = itens;

			insertSynchro.WaitOne ();

			//populates it with data in the cache
			do
			{                
				key = CreateRandomString(127, Thread.CurrentThread.ManagedThreadId + cont);
				keys.Add(key);

				data = CreateRandomString(156000, Thread.CurrentThread.ManagedThreadId + cont + 1);

				cache.Add (key, data);

				cont--;
			}
			while (cont > 0);

			insertDoneSynchro.Release ();

			readSynchro.WaitOne ();

			cont = interactions;
			index = 0;

			//test readings
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();            
			do
			{
				object ci = cache.Get(keys[index]);

				ci = null;
				index++;
				if (index == itens)
				{
					index = 0;
				}

				cont--;
			}
			while (cont > 0);
			stopWatch.Stop();

			readDoneSynchro.Release ();

			string outstring = String.Format("[{0}] number of interactions {1} : {2} milliseconds", Thread.CurrentThread.ManagedThreadId, interactions, stopWatch.ElapsedMilliseconds );
			Console.WriteLine(outstring);

			deleteSynchro.WaitOne ();

			cont = itens-1;

			//populates it with data in the cache
			do
			{
				cache.Remove(keys[cont]);

				cont--;
			}
			while (cont > 0);

			deleteDoneSynchro.Release ();
		}

		const int NB_THREADS = 2;

		public static ManualResetEvent insertSynchro = new ManualResetEvent (false);
		public static ManualResetEvent readSynchro = new ManualResetEvent (false);
		public static ManualResetEvent deleteSynchro = new ManualResetEvent (false);

		public static Semaphore insertDoneSynchro = new Semaphore (0, NB_THREADS);
		public static Semaphore readDoneSynchro = new Semaphore (0, NB_THREADS);
		public static Semaphore deleteDoneSynchro = new Semaphore (0, NB_THREADS);

		static void Main(string[] args)
		{
			List<Thread> threads = new List<Thread> (NB_THREADS);

			for (int i = 0; i < NB_THREADS; ++i)
			{
				Thread thread = new Thread(new ThreadStart(CacheAccessTest));
				threads.Add (thread);
				thread.Start ();
			}

			insertSynchro.Set ();

			for (int i = 0; i < NB_THREADS; ++i) insertDoneSynchro.WaitOne ();

			readSynchro.Set ();

			for (int i = 0; i < NB_THREADS; ++i) readDoneSynchro.WaitOne ();

			deleteSynchro.Set ();

			for (int i = 0; i < NB_THREADS; ++i) deleteDoneSynchro.WaitOne ();


			foreach (Thread thread in threads) {
				thread.Join ();
			}

			Console.WriteLine("End of test.");
			Console.ReadLine();
		}
	}
}
