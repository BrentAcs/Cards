using System.Net.Security;

namespace Cards.Core;

public record Card(CardSuit Suit, CardRank Rank)
{
}

public interface ICardDeck
{
   IEnumerable<Card> Cards { get; }
}

public abstract class CardDeckBase : ICardDeck
{
   protected readonly IList<Card> _cards;

   protected CardDeckBase(IEnumerable<Card>? cards)
   {
      _cards = new List<Card>(cards ?? new List<Card>());
   }

   public IEnumerable<Card> Cards => _cards;
}

public class StandardCardDeck : CardDeckBase
{
   public StandardCardDeck(IEnumerable<Card>? cards) : base(cards)
   {
   }
}

public interface ICardDeckFactory
{
   ICardDeck Create();
}

public abstract class CardDeckFactoryBase : ICardDeckFactory
{
   // shim, for now.
   public abstract ICardDeck Create();
}

public class StandardCardDeckFactory : CardDeckFactoryBase
{
   public override ICardDeck Create()
   {
      var cards = new List<Card>();

      foreach (var suit in Enum.GetValues<CardSuit>())
      {
         cards.AddRange(Enum.GetValues<CardRank>().Select(rank => new Card(suit, rank)));
      }
      
      return new StandardCardDeck(cards);
   }
}
