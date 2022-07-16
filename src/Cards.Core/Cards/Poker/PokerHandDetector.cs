namespace Cards.Core.Cards;

public interface IPokerHandDetector
{
   bool IsRoyalFlush(ICardHand? hand);
   bool IsStraightFlush(ICardHand? hand);
   bool IsFourOfAKind(ICardHand? hand);
   bool IsFullHouse(ICardHand? hand);
   bool IsFlush(ICardHand? hand);
   bool IsStraight(ICardHand? hand);
   bool IsThreeOfAKind(ICardHand? hand);
   bool IsTwoPair(ICardHand? hand);
   bool IsOnePair(ICardHand? hand);
   bool IsHighCard(ICardHand? hand);
}

public class PokerHandDetector : IPokerHandDetector
{
   private static void ValidateHand(ICardHand? hand)
   {
      if (hand is null)
         throw new ArgumentNullException(nameof(hand));
      if (hand.IsEmpty)
         throw new ArgumentOutOfRangeException(nameof(hand), "Hand is empty.");
      if (hand.Count != 5)
         throw new ArgumentOutOfRangeException(nameof(hand), "Hand does not contain 5 cards.");
   }

   private static bool HasSameSuit(ICardHand hand)
   {
      var firstSuit = hand[ 0 ].Suit;
      return hand.Count(c => c.Suit == firstSuit) == 5;
   }

   private static bool HasStraight(ICardHand hand)
   {
      var sortedHand = hand.OrderBy(c => c.Rank).ToList();
      return sortedHand[ 0 ].Rank - sortedHand[ 4 ].Rank == -4;
   }

   private static bool HasThreeOfAKind(ICardHand hand) =>
      Enum.GetValues<CardRank>().Any(rank => hand!.Count(c => c.Rank == rank) == 3);

   private static bool HasPair(ICardHand hand) =>
      Enum.GetValues<CardRank>().Any(rank => hand!.Count(c => c.Rank == rank) == 2);

   public bool IsRoyalFlush(ICardHand? hand)
   {
      ValidateHand(hand);

      if (!IsStraightFlush(hand!))
         return false;

      return hand!.HighCard.Rank == CardRank.Ace;
   }

   public bool IsStraightFlush(ICardHand? hand)
   {
      ValidateHand(hand);

      return HasSameSuit(hand!) && HasStraight(hand!);
   }

   public bool IsFourOfAKind(ICardHand? hand)
   {
      ValidateHand(hand);

      return Enum.GetValues<CardRank>().Any(rank => hand!.Count(c => c.Rank == rank) == 4);
   }

   public bool IsFullHouse(ICardHand? hand)
   {
      ValidateHand(hand);

      return HasThreeOfAKind(hand!) && HasPair(hand!);
   }

   public bool IsFlush(ICardHand? hand)
   {
      ValidateHand(hand);

      return HasSameSuit(hand!) && !HasStraight(hand!);
   }

   public bool IsStraight(ICardHand? hand)
   {
      ValidateHand(hand);

      return !HasSameSuit(hand!) && HasStraight(hand!);
   }

   public bool IsThreeOfAKind(ICardHand? hand)
   {
      ValidateHand(hand);

      return HasThreeOfAKind(hand!);
   }

   public bool IsTwoPair(ICardHand? hand)
   {
      ValidateHand(hand);

      var test = Enum.GetValues<CardRank>().Any(rank => hand!.Count(c => c.Rank == rank) == 2);

      IEnumerable<Card>? firstPair = null;
      foreach (var rank in Enum.GetValues<CardRank>())
      {
         firstPair = hand!.Where(c => c.Rank == rank).ToList();
         if (firstPair.Count() == 2)
            break;
         firstPair = null;
      }

      if (firstPair is null)
         return false;

      var remaining = hand!.Where(c => !firstPair!.Contains(c));

      return Enum.GetValues<CardRank>().Any(rank => remaining!.Count(c => c.Rank == rank) == 2);
   }

   public bool IsOnePair(ICardHand? hand)
   {
      ValidateHand(hand);

      return !IsTwoPair(hand) && HasPair(hand!);
   }

   public bool IsHighCard(ICardHand? hand)
   {
      ValidateHand(hand);

      return (!IsRoyalFlush(hand) &&
              !IsStraightFlush(hand) &&
              !IsFourOfAKind(hand) &&
              !IsFullHouse(hand) &&
              !IsFlush(hand) &&
              !IsStraight(hand) &&
              !IsThreeOfAKind(hand) &&
              !IsTwoPair(hand) &&
              !IsOnePair(hand));
   }
}
