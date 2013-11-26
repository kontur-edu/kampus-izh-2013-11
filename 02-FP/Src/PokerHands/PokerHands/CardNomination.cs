using System;

namespace PokerHands
{
	public abstract class CardNomination : IComparable<CardNomination>
	{
		public readonly int Value;

		protected CardNomination(int value)
		{
			Value = value;
		}

		public int CompareTo(CardNomination other)
		{
			if (Value < other.Value)
				return -1;

			return Value > other.Value ? 1 : 0;
		}

		protected bool Equals(CardNomination other)
		{
			return Value == other.Value;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CardNomination)obj);
		}

		public override int GetHashCode()
		{
			return Value;
		}

		public static bool operator <(CardNomination nomination1, CardNomination nomination2)
		{
			return nomination1.CompareTo(nomination2) < 0;
		}

		public static bool operator >(CardNomination nomination1, CardNomination nomination2)
		{
			return nomination1.CompareTo(nomination2) > 0;
		}

		public static bool operator ==(CardNomination nomination1, CardNomination nomination2)
		{
			return Equals(nomination1, nomination2);
		}

		public static bool operator !=(CardNomination nomination1, CardNomination nomination2)
		{
			return !(nomination1 == nomination2);
		}

		public abstract bool Is(dynamic d);
	}

	public class MinorCardNomination : CardNomination
	{
		public MinorCardNomination(int value)
			: base(value)
		{
			if (value < 2 || value > 10)
				throw new ArgumentException();
		}

		public override bool Is(dynamic d)
		{
			if (d is int)
				return Value == d;

			return false;
		}
	}

	public class MajorCardNomination : CardNomination
	{
		public MajorCardNomination(MajorCardType majorCardType)
			: base(GetMajorCardValue(majorCardType))
		{
		}

		private static int GetMajorCardValue(MajorCardType majorCardType)
		{
			switch (majorCardType)
			{
				case MajorCardType.Ace: return 14;
				case MajorCardType.King: return 13;
				case MajorCardType.Queen: return 12;
				case MajorCardType.Jack: return 11;
				default: throw new ArgumentException();
			}
		}

		public override bool Is(dynamic d)
		{
			if (d is MajorCardType)
				return Value == GetMajorCardValue(d);

			return false;
		}
	}

	public enum MajorCardType
	{
		Ace = 14,
		King = 13,
		Queen = 12,
		Jack = 11
	}

	public enum Suit
	{
		Spades,
		Clubs,
		Hearts,
		Diamonds
	}
}