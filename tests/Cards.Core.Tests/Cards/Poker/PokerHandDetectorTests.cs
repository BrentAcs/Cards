using Cards.Core.Cards;

namespace Cards.Core.Tests.Cards.Poker;

public class PokerHandDetectorTests
{
   private readonly IPokerHandDetector _detector = new PokerHandDetector();

   [Fact]
   public void IsRoyalFlush_ThrowsException_WhenHandIsNull()
   {
      var act = () => _detector.IsRoyalFlush(null);

      act.Should().Throw<ArgumentNullException>();
   }

   [Fact]
   public void IsRoyalFlush_ThrowsException_WhenHandIsEmpty()
   {
      var act = () => _detector.IsRoyalFlush(new CardHand());

      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void IsRoyalFlush_ThrowsException_WhenHandContainsNotFiveCards()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Ace),
         new Card(CardSuit.Spades, CardRank.King),
         new Card(CardSuit.Spades, CardRank.Queen),
      });

      var act = () => _detector.IsRoyalFlush(hand);

      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   // ----- IsRoyalFlush
   
   [Fact]
   public void IsRoyalFlush_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Ace),
         new Card(CardSuit.Spades, CardRank.King),
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank.Jack),
         new Card(CardSuit.Spades, CardRank._10),
      });

      var isMatch = _detector.IsRoyalFlush(hand);

      isMatch.Should().BeTrue();
   }

   [Fact]
   public void IsRoyalFlush_IsTrue_RanksOutOfOrder()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.King),
         new Card(CardSuit.Spades, CardRank.Ace),
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Spades, CardRank.Jack),
      });

      var isMatch = _detector.IsRoyalFlush(hand);

      isMatch.Should().BeTrue();
   }

   [Fact]
   public void IsRoyalFlush_IsFalse_OnOddSuit()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Ace),
         new Card(CardSuit.Spades, CardRank.King),
         new Card(CardSuit.Diamonds, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank.Jack),
         new Card(CardSuit.Spades, CardRank._10),
      });

      var isMatch = _detector.IsRoyalFlush(hand);

      isMatch.Should().BeFalse();
   }
   
   // ----- IsStraightFlush

   [Fact]
   public void IsStraitFlush_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank.Jack),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Spades, CardRank._9),
         new Card(CardSuit.Spades, CardRank._8),
      });

      var isMatch = _detector.IsStraightFlush(hand);

      isMatch.Should().BeTrue();
   }
   
   // ----- IsFourOfAKind

   [Fact]
   public void IsFourOfAKind_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank.Queen),
         new Card(CardSuit.Diamonds, CardRank.Queen),
      });

      var isMatch = _detector.IsFourOfAKind(hand);

      isMatch.Should().BeTrue();
   }

   // ----- IsFullHouse

   [Fact]
   public void IsFullHouse_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank._10),
         new Card(CardSuit.Diamonds, CardRank._10),
      });

      var isMatch = _detector.IsFullHouse(hand);

      isMatch.Should().BeTrue();
   }

   // ----- IsFlush

   [Fact]
   public void IsFlush_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Clubs, CardRank.Ace),
         new Card(CardSuit.Clubs, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank._10),
         new Card(CardSuit.Clubs, CardRank._5),
         new Card(CardSuit.Clubs, CardRank._2),
      });

      var isMatch = _detector.IsFlush(hand);

      isMatch.Should().BeTrue();
   }
   
   [Fact]
   public void IsFlush_IsFalse_OnStraightFlush()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank.Jack),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Spades, CardRank._9),
         new Card(CardSuit.Spades, CardRank._8),
      });

      var isMatch = _detector.IsFlush(hand);

      isMatch.Should().BeFalse();
   }

   [Fact]
   public void IsFlush_IsFalse_OnRoyalFlush()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Ace),
         new Card(CardSuit.Spades, CardRank.King),
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank.Jack),
         new Card(CardSuit.Spades, CardRank._10),
      });

      var isMatch = _detector.IsFlush(hand);

      isMatch.Should().BeFalse();
   }

   // ----- IsStraight

   [Fact]
   public void IsStrait_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Jack),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank._9),
         new Card(CardSuit.Spades, CardRank._8),
      });

      var isMatch = _detector.IsStraight(hand);

      isMatch.Should().BeTrue();
   }

   [Fact]
   public void IsStrait_IsFalse_OnStraightFlush()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank.Jack),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Spades, CardRank._9),
         new Card(CardSuit.Spades, CardRank._8),
      });

      var isMatch = _detector.IsStraight(hand);

      isMatch.Should().BeFalse();
   }
   
   // ----- IsThreeOfAKind

   [Fact]
   public void IsThreeOfAKind_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank.Queen),
         new Card(CardSuit.Diamonds, CardRank.King),
      });

      var isMatch = _detector.IsThreeOfAKind(hand);

      isMatch.Should().BeTrue();
   }

   [Fact]
   public void IsThreeOfAKind_IsFalse_OnFourOfAKind()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank.Queen),
         new Card(CardSuit.Diamonds, CardRank.Queen),
      });

      var isMatch = _detector.IsThreeOfAKind(hand);

      isMatch.Should().BeFalse();
   }

   // ----- IsTwoPair

   [Fact]
   public void IsTwoPair_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank._5),
         new Card(CardSuit.Diamonds, CardRank._5),
      });

      var isMatch = _detector.IsTwoPair(hand);

      isMatch.Should().BeTrue();
   }

   [Fact]
   public void IsTwoPair_IsFalse_EdgeCase()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Ace),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank._5),
         new Card(CardSuit.Diamonds, CardRank._5),
      });

      var isMatch = _detector.IsTwoPair(hand);

      isMatch.Should().BeFalse();
   }

   // ----- IsTwoPair

   [Fact]
   public void IsOnePair_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Ace),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank._5),
         new Card(CardSuit.Diamonds, CardRank._5),
      });
   
      var isMatch = _detector.IsOnePair(hand);
   
      isMatch.Should().BeTrue();
   }
   
   [Fact]
   public void IsOnePair_IsFalse_OnTwoPair()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Queen),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank._5),
         new Card(CardSuit.Diamonds, CardRank._5),
      });

      var isMatch = _detector.IsOnePair(hand);

      isMatch.Should().BeFalse();
   }

   // ----- IsTwoPair

   [Fact]
   public void IsHighCard_IsTrue()
   {
      var hand = new CardHand(new []
      {
         new Card(CardSuit.Spades, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank.Ace),
         new Card(CardSuit.Spades, CardRank._10),
         new Card(CardSuit.Hearts, CardRank._5),
         new Card(CardSuit.Diamonds, CardRank._3),
      });
   
      var isMatch = _detector.IsHighCard(hand);
   
      isMatch.Should().BeTrue();
   }
}
