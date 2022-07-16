namespace Cards.Core.Cards;

public enum CardSuit
{
   Diamonds = 1,
   Clubs,
   Hearts,
   Spades
}

public enum CardRank
{
   Ace = 1,
   King,
   Queen,
   Jack,
   _10,
   _9,
   _8,
   _7,
   _6,
   _5,
   _4,
   _3,
   _2,
}

public enum PokerHands
{
   RoyalFlush = 1,
   StraightFlush,
   FourOfAKind,
   FullHouse,
   Flush,
   Straight,
   ThreeOfAKind,
   TwoPair,
   OnePair,
   HighCard,
}
