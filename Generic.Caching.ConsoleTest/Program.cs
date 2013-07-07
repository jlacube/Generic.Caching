using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using Generic.Caching;

namespace Generic.Caching.ConsoleTest
{
	class MainClass
	{        
		private static ICacheType<string> cache = new Cache<string>();
		private static string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
		private static int counter = 0;
		private static readonly object locker = new object();

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

		private static void CacheAccessTes()
		{
			int span = 5;
			string key;
			string data;
			int itens = 1000;
			int interactions = 1000000;
			int cont = 0;
			int index = 0;
			List<string> keys = new List<string>();

			lock (locker)
			{
				counter++;
			}

			cont = itens;

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

			lock (locker)
			{
				counter--;
			}

			string outstring = String.Format("[{0}] number of interactions {1} : {2} milliseconds", Thread.CurrentThread.ManagedThreadId, interactions, stopWatch.ElapsedMilliseconds );
			Console.WriteLine(outstring);
		}

		static void Main(string[] args)
		{
			for (int threads = 0; threads < 2; threads++)
			{
				Thread thread = new Thread(new ThreadStart(CacheAccessTes));
				thread.Start();
			}

			Thread.Sleep(1000);

			while (true)
			{
				lock (locker)
				{
					if (counter == 0) break;
				}
				Thread.Sleep(100);
			}

			Console.WriteLine("End of test.");
			Console.ReadLine();
		}
	}
}
