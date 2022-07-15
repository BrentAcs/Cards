namespace Cards.Core.Utilities;

public sealed class CryptoRng :IRng
{
   public static CryptoRng Instance { get; } = new CryptoRng();

   public int Next() =>
      throw new NotImplementedException();

   public int Next(int maxValue) =>
      RandomNumberGenerator.GetInt32(maxValue);

   public int Next(int minValue, int maxValue) =>
      RandomNumberGenerator.GetInt32(minValue, maxValue);

   public double Next(double minimum, double maximum) =>
      throw new NotImplementedException();

   public int NextD4() =>
      Next(1, 4);

   public int NextD6() =>
      Next(1, 6);

   public int NextD8() =>
      Next(1, 8);

   public int NextD10() =>
      Next(1, 10);

   public int NextD100() =>
      Next(1, 100);
}
