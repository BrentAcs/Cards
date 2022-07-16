using Cards.Core.Cards;

namespace Cards.Core.Extensions;

public static class CardExtensions
{
   public static string ToConsoleDisplay(this Card? card) 
   {
      if (card is null)
         return string.Empty;

      var rank = $"{card.Rank}".TrimStart('_');
      return $"[{rank} of {card.Suit}]";
   }

}
