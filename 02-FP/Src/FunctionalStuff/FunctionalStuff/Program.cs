using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FunctionalStuff
{
	class Program
	{
		static int FactorialImperative(int n)
		{
			var acc = 1;
			var x = n;
			while (x > 0){ acc = acc * x--;}
			return acc;
		}

		static int FactorialLinear(int n)
		{
			return n <= 1? 1
				: n * FactorialLinear(n - 1);
		}

		static int FactorialTail(int n)
		{
			Func<int, int, int> factorialIter = null;
			factorialIter = (acc, x) => x <= 0 ? acc : factorialIter(x * acc, x - 1);

			return factorialIter(1, n);
		}

		static int FibRecursion(int n)
		{
			return n == 0? 0
					: n <= 2? 1
						: FibRecursion(n - 2) + FibRecursion(n - 1);
		}

		static int FibRepeat(int n)
		{
			return Enumerable.Range(1, n - 2).
				Aggregate(new {i1 = 1, i2 = 1}, (acc, i) => new {i1 = acc.i2, i2 = acc.i1 + acc.i2}).i2;
		}

		static int FibTailRecursion(int n)
		{
			Func<int, int, int, int> fibRecursionIter = null;
			fibRecursionIter = (fib2, fib1, k) =>
								k >= n? fib1 + fib2
									: fibRecursionIter(fib1, fib1 + fib2, k + 1);
			return fibRecursionIter(1, 1, 3);
		}

		static Func<T, U> Memoize<T, U>(Func<T, U> f)
		{
			var cache = new Dictionary<T, U>();

			return arg =>
			{
				if (!cache.ContainsKey(arg))
					cache[arg] = f(arg);
				return cache[arg];
			};
		}

		static void Main(string[] args)
		{
			var memoFib = Memoize<int, int>(FibRecursion);
			var sw =new Stopwatch();
			string answer;
			do
			{
				Console.WriteLine("enter number to calculate or press enter to exit");
				answer = Console.ReadLine();
				if (string.IsNullOrEmpty(answer)) return;
				sw.Start();
				Console.WriteLine(Problem59.Solve("cipher1.txt"));
				sw.Stop();
				Console.WriteLine("Time: " + sw.ElapsedMilliseconds);
				sw.Reset();
			} while (true);
		}
	}
}
