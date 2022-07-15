namespace Cards.Core;

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
