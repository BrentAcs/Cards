using Cards.Core.Utilities;

namespace Cards.Core.Extensions;

public static class IListExtensions
{
   public static void Shuffle<T>(this IList<T> list, IRng? rng =null)
   {
      rng ??= CryptoRng.Instance;

      int current = list.Count;
      while (current > 1)
      {
         int swapIndex = rng.Next(current);
         Console.WriteLine($"{current} of {list.Count}: {swapIndex}");
         current--;
         (list[current], list[swapIndex]) = (list[swapIndex], list[current]);
      }
   }
}
