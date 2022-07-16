using Cards.Core.Extensions;

namespace Cards.Core.Cards;

public interface ICardCollection : IReadOnlyList<Card>
{
   bool IsEmpty { get; }
   
   void Add(Card card);
   bool Remove(Card card);
}

public interface ICardDeck : ICardCollection
{
   void Shuffle(int times = 10);
}

public abstract class CardCollection : ICardCollection
{
   protected readonly IList<Card> _cards;

   protected CardCollection(IEnumerable<Card>? cards = null)
   {
      _cards = new List<Card>(cards ?? new List<Card>());
   }

   public int Count => _cards.Count;
   public Card this[int index] => _cards[ index ];

   public IEnumerator<Card> GetEnumerator() => _cards.GetEnumerator();
   IEnumerator IEnumerable.GetEnumerator() => _cards.GetEnumerator();

   public bool IsEmpty => _cards.Count == 0;
   public void Add(Card card) => _cards.Add(card);
   public bool Remove(Card card) => _cards.Remove(card);
}


public class StandardCardDeck : CardCollection, ICardDeck
{
   public StandardCardDeck(IEnumerable<Card>? cards = null) : base(cards)
   {
   }

   public void Shuffle(int times = 5) =>
      _cards.Shuffle(5);
}
