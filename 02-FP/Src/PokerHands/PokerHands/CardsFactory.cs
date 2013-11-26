using System;
using System.Linq;
using MoreLinq;

namespace PokerHands
{
	public static class CardsFactory
	{
		public static Card[][] GetCardSets(string line)
		{
			return line.Split(' ').Batch(5).Select(cardStr => cardStr.Select(str =>
				{
					CardNomination nomination;
					switch (str[0])
					{
						case 'A': nomination = new MajorCardNomination(MajorCardType.Ace); break;
						case 'K': nomination = new MajorCardNomination(MajorCardType.King); break;
						case 'Q': nomination = new MajorCardNomination(MajorCardType.Queen); break;
						case 'J': nomination = new MajorCardNomination(MajorCardType.Jack); break;
						case 'T': nomination = new MinorCardNomination(10); break;
						default: nomination = new MinorCardNomination(int.Parse(str[0].ToString())); break;
					}
					Suit suit;
					switch (str[1])
					{
						case 'C': suit = Suit.Clubs; break;
						case 'D': suit = Suit.Diamonds; break;
						case 'H': suit = Suit.Hearts; break;
						case 'S': suit = Suit.Spades; break;
						default: throw new ArgumentException();
					}
					return new Card(nomination, suit);
				}).ToArray()).ToArray();
		}
	}
}