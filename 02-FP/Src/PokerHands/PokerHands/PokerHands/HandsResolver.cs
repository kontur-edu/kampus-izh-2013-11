using System;
using System.Linq;

namespace PokerHands
{
	public static class HandsResolver
	{
		public static bool IsPlayer1Wins(Card[][] cardSets)
		{
			return GetHand(cardSets.First().OrderByDescending(c => c.CardNomination).ToArray())
				.CompareTo(GetHand(cardSets.Skip(1).First().OrderByDescending(c => c.CardNomination).ToArray()))
				== 1;
		}

		private static Hand GetHand(Card[] cardSet)
		{
			return
				new Hand(CombinationFactory.TryGetRoyalFlush(cardSet))
					.Or(() => new Hand(CombinationFactory.TryGetStraightFlush(cardSet)))
					.Or(()=> CreateHand(CombinationFactory.TryGetFourOfAKind(cardSet)))
					.Or(() => new Hand(CombinationFactory.TryGetFullHouse(cardSet)))
					.Or(() => new Hand(CombinationFactory.TryGetFlush(cardSet)))
					.Or(() => new Hand(CombinationFactory.TryGetStraight(cardSet)))
					.Or(() => CreateHand(CombinationFactory.TryGetThreeOfAKind(cardSet)))
					.Or(() => CreateHand(CombinationFactory.TryGetTwoPairs(cardSet)))
					.Or(() => CreateHand(CombinationFactory.TryGetPair(cardSet)))
					.Or(() => new Hand(null, new OddCards(cardSet.Select(c => c.CardNomination).ToArray())));
		}

		private static Hand CreateHand(dynamic tuple)
		{
			return tuple == null? null : new Hand(tuple.Item1, new OddCards(tuple.Item2));
		}

		private static Hand Or(this Hand hand1, Func<Hand> hand2)
		{
			return hand1 != null && hand1.Combination != null ? hand1 : hand2();
		}
	}
}