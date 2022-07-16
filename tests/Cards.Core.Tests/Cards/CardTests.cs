using Cards.Core.Cards;

namespace Cards.Core.Tests.Cards;

public class CardTests
{
   [Theory]
   [InlineData(CardSuit.Clubs, false)]
   [InlineData(CardSuit.Diamonds, true)]
   [InlineData(CardSuit.Hearts, true)]
   [InlineData(CardSuit.Spades, false)]
   public void IsRed_Checks(CardSuit suit, bool expected)
   {
      var sut = new Card(suit, CardRank._2);

      sut.IsRed.Should().Be(expected);
   }

   [Theory]
   [InlineData(CardSuit.Clubs, true)]
   [InlineData(CardSuit.Diamonds, false)]
   [InlineData(CardSuit.Hearts, false)]
   [InlineData(CardSuit.Spades, true)]
   public void IsBlack_Checks(CardSuit suit, bool expected)
   {
      var sut = new Card(suit, CardRank._2);

      sut.IsBlack.Should().Be(expected);
   }
}
