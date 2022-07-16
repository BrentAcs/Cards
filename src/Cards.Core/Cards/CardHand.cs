namespace Cards.Core.Cards;

// Royal flush
// Straight flush
// Four of a kind
// Full house
// Flush
// Straight
// Three of a kind
// Two pair
// One pair
// High card

public interface ICardHand : ICardCollection
{
   Card HighCard { get; }
}

public class CardHand : CardCollection, ICardHand
{
   public CardHand(IEnumerable<Card>? cards = null) : base(cards)
   {
   }

   public Card HighCard => GetHighCard();

   private Card GetHighCard() =>
      this.OrderBy(c => c.Rank).ToList()[ 0 ];
}
