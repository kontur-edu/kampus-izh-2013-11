using System;
using System.Linq;

namespace PokerHands
{
	public class Combination : IComparable<Combination>
	{
		protected int Value { get; set; }
		public CardNomination MainCard { get; protected set; }

		public Combination(int value, CardNomination mainCard)
		{
			Value = value;
			MainCard = mainCard;
		}

		public virtual int CompareTo(Combination other)
		{
			if (other == null || Value > other.Value)
				return 1;

			if (Value < other.Value)
				return -1;

			if (MainCard == null && other.MainCard == null)
				return 0;

			return MainCard.CompareTo(other.MainCard);
		}

		public static bool operator ==(Combination combination1, Combination combination2)
		{
			return Equals(combination1, combination2);
		}

		public static bool operator !=(Combination combination1, Combination combination2)
		{
			return !(combination1 == combination2);
		}

		protected bool Equals(Combination other)
		{
			return Value == other.Value && Equals(MainCard, other.MainCard);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Combination)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Value * 397) ^ (MainCard != null ? MainCard.GetHashCode() : 0);
			}
		}
	}

	public class Pair : Combination
	{
		protected Pair(int value, CardNomination mainCard) : base(value, mainCard) { }
		public Pair(CardNomination cardNomination) : this(1, cardNomination) { }
	}

	public class TwoPairs : Combination
	{
		public readonly CardNomination MinorCardNomination;

		public TwoPairs(CardNomination[] cardNominations)
			: base(2, cardNominations.Max())
		{
			MinorCardNomination = cardNominations.Min();
		}

		public override int CompareTo(Combination other)
		{
			var baseRes =  base.CompareTo(other);

			if (baseRes != 0)
				return baseRes;

			if (!(other is TwoPairs))
				throw new ArgumentException();

			return MinorCardNomination.CompareTo((other as TwoPairs).MinorCardNomination);
		}
	}

	public class ThreeOfAKind : Pair
	{
		public ThreeOfAKind(CardNomination mainCard)
			: base(3, mainCard)
		{
		}
	}

	public class Straight : Combination
	{
		protected Straight(int value, CardNomination mainCard) : base(value, mainCard) { }
		public Straight(CardNomination cardNomination) : this(4, cardNomination) { }
	}

	public class Flush : Combination
	{
		protected readonly OddCards Cards;

		public Flush(CardNomination[] cardNominations)
			: base(5, cardNominations.First())
		{
			Cards = new OddCards(cardNominations.Skip(1).ToArray());
		}

		public override int CompareTo(Combination other)
		{
			var baseRes =  base.CompareTo(other);

			if (baseRes != 0)
				return baseRes;

			if (!(other is Flush))
				throw new ArgumentException();

			return Cards.CompareTo((other as Flush).Cards);
		}
	}

	public class FullHouse : Combination
	{
		protected readonly CardNomination PairCardNomination;

		public FullHouse(CardNomination threeCardNomination, CardNomination pairCardNomination)
			: base(6, threeCardNomination)
		{
			PairCardNomination = pairCardNomination;
		}

		public override int CompareTo(Combination other)
		{
			var baseRes = base.CompareTo(other);

			if (baseRes != 0)
				return baseRes;

			if (!(other is FullHouse))
				throw new ArgumentException();

			return PairCardNomination.CompareTo((other as FullHouse).PairCardNomination);
		}
	}

	public class FourOfAKind : Pair
	{
		public FourOfAKind(CardNomination mainCard) : base(7, mainCard) { }
	}

	public class StraightFlush : Straight
	{
		public StraightFlush(CardNomination mainCard)
			: base(8, mainCard)
		{
		}
	}

	public class RoyalFlush : Combination
	{
		public RoyalFlush() : base(9, new MajorCardNomination(MajorCardType.Ace)) { }
	}
}