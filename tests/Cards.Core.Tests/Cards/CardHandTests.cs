using Cards.Core.Cards;

namespace Cards.Core.Tests.Cards;

public class CardHandTests
{
   [Fact]
   public void HighCard_Test()
   {
      var sut = new CardHand(new[]
      {
         new Card(CardSuit.Clubs, CardRank._4),
         new Card(CardSuit.Clubs, CardRank._3),
         new Card(CardSuit.Clubs, CardRank._8),
         new Card(CardSuit.Clubs, CardRank.Queen),
         new Card(CardSuit.Clubs, CardRank._6),
      });

      var highCard = sut.HighCard;

      highCard.Rank.Should().Be(CardRank.Queen);
   }
}
