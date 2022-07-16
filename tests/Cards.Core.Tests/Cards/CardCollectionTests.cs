using Cards.Core.Cards;

namespace Cards.Core.Tests.Cards;

public class CardCollectionTests
{
   private class TestableCardCollection : CardCollection
   {
      public TestableCardCollection(IEnumerable<Card>? cards = null) : base(cards) { }
   }

   [Fact]
   public void Add_WillIncreaseCountBy1()
   {
      var card = new Card(CardSuit.Spades, CardRank.Ace);
      var sut = new TestableCardCollection();
      var priorCount = sut.Count;

      sut.Add(card);

      sut.Count.Should().Be(priorCount + 1);
   }
   
   [Fact]
   public void Remove_WillDecreaseCountBy1()
   {
      var card = new Card(CardSuit.Spades, CardRank.Ace);
      var sut = new TestableCardCollection();
      sut.Add(card);
      var priorCount = sut.Count;

      sut.Remove(card);

      sut.Count.Should().Be(priorCount - 1);
   }
   
}
