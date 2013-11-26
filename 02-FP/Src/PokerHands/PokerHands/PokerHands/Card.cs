namespace PokerHands
{
	public class Card
	{
		public readonly CardNomination CardNomination;
		public readonly Suit Suit;

		public Card(CardNomination cardNomination, Suit suit)
		{
			CardNomination = cardNomination;
			Suit = suit;
		}

		public static bool operator ==(Card card1, Card card2)
		{
			return Equals(card1, card2);
		}

		public static bool operator !=(Card card1, Card card2)
		{
			return !(card1 == card2);
		}

		protected bool Equals(Card other)
		{
			return Equals(CardNomination, other.CardNomination) && Suit == other.Suit;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Card)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((CardNomination != null ? CardNomination.GetHashCode() : 0) * 397) ^ (int)Suit;
			}
		}
	}
}