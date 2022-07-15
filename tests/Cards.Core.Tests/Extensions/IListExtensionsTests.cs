using Cards.Core.Extensions;
using Cards.Core.Utilities;
using Moq;

namespace Cards.Core.Tests.Extensions;

public class IListExtensionsTests
{
   [Fact]
   public void Shuffle_WillReturn_ShuffledList()
   {
      var list = new List<int> { 1, 2, 3, 4, 5 };

      var rngMock = new Mock<IRng>();
      rngMock.Setup(m => m.Next(4)).Returns(3);
      rngMock.Setup(m => m.Next(3)).Returns(2);
      rngMock.Setup(m => m.Next(2)).Returns(1);
      rngMock.Setup(m => m.Next(1)).Throws(new Exception());

      list.Shuffle();
   }
}
