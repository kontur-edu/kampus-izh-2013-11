using System;
using System.Diagnostics;
using System.Linq;

namespace PokerHands
{
	public static class CombinationFactory
	{
		public static RoyalFlush TryGetRoyalFlush(Card[] cards)
		{
			if (cards.First().CardNomination.Is(MajorCardType.Ace) && TryGetStraightFlush(cards) != null)
				return new RoyalFlush();

			return null;
		}

		public static StraightFlush TryGetStraightFlush(Card[] cards)
		{
			var straight = TryGetStraight(cards);
			return straight != null && TryGetFlush(cards) != null
						? new StraightFlush(straight.MainCard)
						: null;
		}

		public static Tuple<FourOfAKind, Card[]> TryGetFourOfAKind(Card[] cards)
		{
			var tuple = GetNominationWithLength(4, cards);
			return (tuple != null)
				? new Tuple<FourOfAKind, Card[]>(new FourOfAKind(tuple.Item1), tuple.Item2)
				: null;
		}

		private static Tuple<CardNomination, Card[]> GetNominationWithLength(int length, Card[] cards, CardNomination exclude = null)
		{
			var group = (exclude == null
								? cards
								: cards.Where(c => c.CardNomination != exclude))
				.GroupBy(c => c.CardNomination).FirstOrDefault(g => g.Count() == length);

			var card = group == null? null : group.FirstOrDefault();
			return card == null
				? null
				: new Tuple<CardNomination, Card[]>(card.CardNomination, cards.Where(c => c.CardNomination != card.CardNomination).ToArray());
		}

		public static FullHouse TryGetFullHouse(Card[] cards)
		{
			var threeCardTuple = GetNominationWithLength(3, cards);
			var pairCardTuple = GetNominationWithLength(2, cards);

			return (threeCardTuple != null && pairCardTuple != null)
				? new FullHouse(threeCardTuple.Item1, pairCardTuple.Item1) 
				: null;
		}

		public static Flush TryGetFlush(Card[] cards)
		{
			return cards.Skip(1).Aggregate(
				new {Flush = true, cards.First().Suit},
				(acc, card) => new { Flush = acc.Flush && acc.Suit == card.Suit, card.Suit } 
				).Flush
					? new Flush(cards.Select(c => c.CardNomination).ToArray())
					: null;
		}

		public static Straight TryGetStraight(Card[] cards)
		{
			var first = cards.First();
			return cards.Skip(1).Aggregate(new {IsStraight = true, Card = first}, (acc, card) => new
				{
					IsStraight = acc.IsStraight && acc.Card.CardNomination.Value - card.CardNomination.Value == 1, Card = card
				}).IsStraight
						? new Straight(first.CardNomination)
						// A,5,4,3,2
						: cards.Select(c => c.CardNomination)
							.Except(new CardNomination[] { new MajorCardNomination(MajorCardType.Ace), new MinorCardNomination(5), new MinorCardNomination(4), new MinorCardNomination(3), new MinorCardNomination(2) }).Any()
								? null
								: new Straight(new MinorCardNomination(5));

		}

		public static Tuple<ThreeOfAKind, Card[]> TryGetThreeOfAKind(Card[] cards)
		{
			var tuple = GetNominationWithLength(3, cards);
			return (tuple != null)
				? new Tuple<ThreeOfAKind, Card[]>(new ThreeOfAKind(tuple.Item1), tuple.Item2)
				: null;
		}

		public static Tuple<TwoPairs, Card[]> TryGetTwoPairs(Card[] cards)
		{
			var tuple1 = GetNominationWithLength(2, cards);

			if (tuple1 == null)
				return null;

			var tuple2 = GetNominationWithLength(2, cards, tuple1.Item1);
			return (tuple2 != null)
				? new Tuple<TwoPairs, Card[]>(new TwoPairs(new[] { tuple1.Item1, tuple2.Item1 }), tuple2.Item2)
				: null;
		}

		public static Tuple<Pair, Card[]> TryGetPair(Card[] cards)
		{
			var tuple = GetNominationWithLength(2, cards);
			return (tuple != null)
				? new Tuple<Pair, Card[]>(new Pair(tuple.Item1), tuple.Item2)
				: null;
		}
	}
}