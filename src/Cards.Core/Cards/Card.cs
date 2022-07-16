namespace Cards.Core.Cards;

public record Card(CardSuit Suit, CardRank Rank)
{
   public bool IsRed => Suit is CardSuit.Diamonds or CardSuit.Hearts;
   public bool IsBlack => Suit is CardSuit.Spades or CardSuit.Clubs;

   public static Card AceOfSpades => new Card(CardSuit.Spades, CardRank.Ace);
}


