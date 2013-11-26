using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MoreLinq;

namespace PokerHands
{
	class Program
	{
		static void Main(string[] args)
		{
			var sw = new Stopwatch();
			sw.Start();
			Console.WriteLine(File.ReadAllLines("TestData\\poker.txt").Count(line => HandsResolver.IsPlayer1Wins(CardsFactory.GetCardSets(line))));
			new[] {4, 5, 6}.MaxBy(i => Math.Sin(i));
			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds);
			Console.ReadKey();
		}
	}
}
