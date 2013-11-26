using System;
using NUnit.Framework;

namespace PokerHands.Tests
{
	[TestFixture]
	public class CombinationFactoryTests
	{
		const Suit Clubs = Suit.Clubs;

		[Test]
		public void TestRoyalFlush([Values(true, false)]bool draw)
		{
			var assert = draw
				? (Action<object>)(Assert.IsNull) 
				: o => Assert.IsNotNull(o);

			assert(CombinationFactory.TryGetRoyalFlush(
				new[]
					{
						new Card(new MajorCardNomination(MajorCardType.Ace), Clubs),
						new Card(new MajorCardNomination(MajorCardType.King), Clubs),
						new Card(new MajorCardNomination(MajorCardType.Queen), Clubs),
						new Card(new MajorCardNomination(MajorCardType.Jack), Clubs),
						new Card(new MinorCardNomination(10), draw? Suit.Diamonds : Clubs),
					}));
		}

		[Test]
		public void TestFlush([Values(true, false)]bool draw)
		{
			var assert = draw
				? (Action<object>)(Assert.IsNull)
				: o => Assert.IsNotNull(o);

			assert(CombinationFactory.TryGetFlush(
				new[]
					{
						new Card(new MajorCardNomination(MajorCardType.Ace), Clubs),
						new Card(new MajorCardNomination(MajorCardType.King), Clubs),
						new Card(new MajorCardNomination(MajorCardType.Queen), Clubs),
						new Card(new MajorCardNomination(MajorCardType.Jack), Clubs),
						new Card(new MinorCardNomination(10), draw? Suit.Diamonds : Clubs),
					}));
		}

		[Test]
		public void TestStraight([Values(true, false)]bool draw)
		{
			var assert = draw
				? (Action<object>)(Assert.IsNull)
				: o => Assert.IsNotNull(o);

			assert(CombinationFactory.TryGetStraight(
				new[]
					{
						new Card(new MajorCardNomination(MajorCardType.Ace), Clubs),
						new Card(new MajorCardNomination(MajorCardType.King), Clubs),
						new Card(new MajorCardNomination(MajorCardType.Queen), Clubs),
						new Card(new MajorCardNomination(MajorCardType.Jack), Clubs),
						new Card(new MinorCardNomination(draw? 9 : 10), Suit.Diamonds),
					}));
		}
	}
}