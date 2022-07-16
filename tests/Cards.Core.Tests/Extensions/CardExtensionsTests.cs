using Cards.Core.Cards;
using Cards.Core.Extensions;

namespace Cards.Core.Tests.Extensions;

public class CardExtensionsTests
{
   [Theory]
   [InlineData(CardSuit.Spades, CardRank.Ace, "[Ace of Spades]")]
   [InlineData(CardSuit.Diamonds, CardRank._8, "[8 of Diamonds]")]
   public void ToConsoleDisplay_Cases(CardSuit suit, CardRank rank, string expected)
   {
      var card = new Card(suit, rank);

      var display = card.ToConsoleDisplay();

      display.Should().Be(expected);
   }
}
