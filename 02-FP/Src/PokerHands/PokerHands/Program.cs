using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PokerHands
{
	class Program
	{
		static void Main(string[] args)
		{
			var sw = new Stopwatch();
			sw.Start();
			Console.WriteLine(File.ReadAllLines("TestData\\poker.txt").Count(line => HandsResolver.IsPlayer1Wins(CardsFactory.GetCardSets(line))));
			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds);
			Console.ReadKey();
		}
	}
}
