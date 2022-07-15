namespace Cards.Core.Utilities;

public sealed class SimpleRng : IRng
{
   private readonly Random _random = new();

   public static IRng Instance { get; } = new SimpleRng();

   public int Next() => _random.Next();
   public int Next(int maxValue) => _random.Next(maxValue);
   public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
   public double Next(double minimum, double maximum) => _random.NextDouble() * (maximum - minimum) + minimum;
   public int NextD4() => _random.Next(1, 5);
   public int NextD6() => _random.Next(1, 7);
   public int NextD8() => _random.Next(1, 9);
   public int NextD10() => _random.Next(1, 11);
   public int NextD100() => _random.Next(1, 101);
}
