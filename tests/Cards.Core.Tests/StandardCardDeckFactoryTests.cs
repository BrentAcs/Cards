using FluentAssertions;

namespace Cards.Core.Tests;

public class StandardCardDeckFactoryTests
{
   private ICardDeckFactory _factory = new StandardCardDeckFactory();

   [Fact]
   public void Create_WillReturn_52Cards()
   {
      var deck = _factory.Create();

      deck.Should().HaveCount(52);
   }
}
