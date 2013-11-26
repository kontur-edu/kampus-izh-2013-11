using System;
using System.Linq;

namespace PokerHands
{
	public class Hand: IComparable<Hand>
	{
		public Combination Combination { get; private set; }
		public OddCards Odd { get; private set; }

		public Hand(Combination combination, OddCards odd = null)
		{
			Combination = combination;
			Odd = odd;
		}

		public int CompareTo(Hand other)
		{
			if (Combination == null && other.Combination != null)
				return -1;

			if (Combination != null && other.Combination == null)
				return 1;
			
			if (Combination != null)
			{
				var combinationCompare = Combination.CompareTo(other.Combination);
				if (combinationCompare != 0)
					return combinationCompare;
			}

			return Odd == null ? 0 : Odd.CompareTo(other.Odd);
		}
	}

	public class OddCards: IComparable<OddCards>
	{
		public readonly CardNomination MainCard;
		public readonly OddCards Odd;

		public OddCards(CardNomination[] cardNominations)
		{
			var nominations = cardNominations.OrderByDescending(n => n).ToArray();
			MainCard = nominations.First();
			var odd = nominations.Skip(1).ToArray();
			Odd = odd.Any()? new OddCards(odd) : null;
		}

		public OddCards(Card[] cards):this(cards.Select(c=>c.CardNomination).ToArray()){}

		public int CompareTo(OddCards other)
		{
			var cardCompare = MainCard.CompareTo(other.MainCard);
			if (cardCompare != 0)
				return cardCompare;

			return Odd == null ? 0 : Odd.CompareTo(other.Odd);
		}
	}
}