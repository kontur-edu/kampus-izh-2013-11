using System.Linq;
using NUnit.Framework;

namespace PokerHands.Tests
{
	[TestFixture]
	public class CardsFactoryTests
	{
		[Test]
		public void GetCardsTest()
		{
			var line = "8C TS KC 9H 4S 7D 2S 5D 3S AC";
			var expected = new[]
				{
					new Card(new MinorCardNomination(8), Suit.Clubs),
					new Card(new MinorCardNomination(10), Suit.Spades),
					new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
					new Card(new MinorCardNomination(9), Suit.Hearts),
					new Card(new MinorCardNomination(4), Suit.Spades),
					new Card(new MinorCardNomination(7), Suit.Diamonds),
					new Card(new MinorCardNomination(2), Suit.Spades),
					new Card(new MinorCardNomination(5), Suit.Diamonds),
					new Card(new MinorCardNomination(3), Suit.Spades),
					new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
				};

			var selectMany = CardsFactory.GetCardSets(line).SelectMany(cards => cards).ToArray();
			Assert.IsTrue(selectMany.Zip(expected, (card1, card2) => card1 == card2).All(b => b));
		}
	}
}