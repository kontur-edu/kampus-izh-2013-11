using NUnit.Framework;

namespace PokerHands.Tests
{
	[TestFixture]
	public class HandsResolverTests
	{
		[Test]
		public void TestOdd1()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Hearts),
							new Card(new MinorCardNomination(2), Suit.Spades),
						},
					new[]
						{
							new Card(new MinorCardNomination(7), Suit.Diamonds),
							new Card(new MinorCardNomination(4), Suit.Spades),
							new Card(new MinorCardNomination(5), Suit.Diamonds),
							new Card(new MinorCardNomination(3), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
						}
				}));
		}
		[Test]
		public void TestOdd2()
		{
			Assert.IsFalse(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Hearts),
							new Card(new MinorCardNomination(2), Suit.Spades),
						},
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Hearts),
							new Card(new MinorCardNomination(2), Suit.Spades),
						}
				}));
		}

		[Test]
		public void TestPair()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MinorCardNomination(9), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.Jack), Suit.Clubs),
							new Card(new MinorCardNomination(2), Suit.Hearts),
							new Card(new MinorCardNomination(3), Suit.Spades),
						},
					new[]
						{
							new Card(new MinorCardNomination(7), Suit.Diamonds),
							new Card(new MinorCardNomination(7), Suit.Spades),
							new Card(new MinorCardNomination(5), Suit.Diamonds),
							new Card(new MinorCardNomination(3), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
						}
				}));
		}
		[Test]
		public void TestTwoPairs()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(8), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(4), Suit.Spades),
						},
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(8), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(3), Suit.Spades),
						}
				}));
		}
		[Test]
		public void TestThreeOfAKind()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(4), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
						},
					new[]
						{
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Hearts),
							new Card(new MinorCardNomination(2), Suit.Spades),
						}
				}));
		}
		[Test]
		public void TestStraight1()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.Jack), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Hearts),
							new Card(new MinorCardNomination(7), Suit.Spades),
						},
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Spades),
							new Card(new MinorCardNomination(6), Suit.Spades),
							new Card(new MinorCardNomination(9), Suit.Hearts),
							new Card(new MinorCardNomination(7), Suit.Spades),
						}
				}));
		}
		[Test]
		public void TestStraight2()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Jack), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.Queen), Suit.Clubs),
						},
					new[]
						{
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Queen), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Jack), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Spades),
							new Card(new MinorCardNomination(10), Suit.Spades),
						}
				}));
		}
		[Test]
		public void TestStraight3()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Jack), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.Queen), Suit.Clubs),
						},
					new[]
						{
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
							new Card(new MinorCardNomination(4), Suit.Spades),
							new Card(new MinorCardNomination(3), Suit.Spades),
							new Card(new MinorCardNomination(5), Suit.Spades),
							new Card(new MinorCardNomination(2), Suit.Spades),
						}
				}));
		}
		[Test]
		public void TestFlush()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Clubs),
							new Card(new MinorCardNomination(3), Suit.Clubs),
						},
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Clubs),
							new Card(new MinorCardNomination(2), Suit.Clubs),
						}
				}));
		}
		[Test]
		public void TestFullHouse()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MinorCardNomination(10), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Spades),
						},
					new[]
						{
							new Card(new MinorCardNomination(9), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Spades),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Spades),
						}
				}));
		}
		[Test]
		public void TestStraightFlush()
		{
			Assert.IsTrue(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Jack), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Clubs),
							new Card(new MinorCardNomination(7), Suit.Clubs),
						},
					new[]
						{
							new Card(new MinorCardNomination(8), Suit.Clubs),
							new Card(new MinorCardNomination(6), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Clubs),
							new Card(new MinorCardNomination(9), Suit.Clubs),
							new Card(new MinorCardNomination(7), Suit.Clubs),
						}
				}));
		}
		[Test]
		public void TestRoyalFush()
		{
			Assert.IsFalse(HandsResolver.IsPlayer1Wins(new[]
				{
					new[]
						{
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Jack), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Queen), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Clubs),
						},
					new[]
						{
							new Card(new MajorCardNomination(MajorCardType.Ace), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Jack), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.Queen), Suit.Clubs),
							new Card(new MajorCardNomination(MajorCardType.King), Suit.Clubs),
							new Card(new MinorCardNomination(10), Suit.Clubs),
						}
				}));
		}
	}
}
