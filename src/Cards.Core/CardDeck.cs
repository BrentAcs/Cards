using System.Collections;

namespace Cards.Core;

public interface ICardDeck : IEnumerable<Card>
{
  
}

public abstract class CardDeckBase : ICardDeck
{
   protected readonly IList<Card> _cards;

   protected CardDeckBase(IEnumerable<Card>? cards)
   {
      _cards = new List<Card>(cards ?? new List<Card>());
   }

   public IEnumerator<Card> GetEnumerator() => _cards.GetEnumerator();

   IEnumerator IEnumerable.GetEnumerator() => _cards.GetEnumerator();
}

public class StandardCardDeck : CardDeckBase
{
   public StandardCardDeck(IEnumerable<Card>? cards) : base(cards)
   {
   }
}
