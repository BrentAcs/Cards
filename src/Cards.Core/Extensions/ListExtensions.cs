using Cards.Core.Utilities;

namespace Cards.Core.Extensions;

public static class ListExtensions
{
   public static void Shuffle<T>(this IList<T> list, int times, IRng? rng = null)
   {
      rng ??= CryptoRng.Instance;
      for (int i = 0; i < times; i++)
      {
         Shuffle(list, rng);
      }
   }

   public static void Shuffle<T>(this IList<T> list, IRng? rng = null)
   {
      rng ??= CryptoRng.Instance;
   
      int current = list.Count;
      while (current > 1)
      {
         int swapIndex = rng.Next(current - 1);
         current--;
         (list[ current ], list[ swapIndex ]) = (list[ swapIndex ], list[ current ]);
      }
   }
}
