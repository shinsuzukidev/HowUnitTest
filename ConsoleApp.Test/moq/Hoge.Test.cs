using Xunit;
using ConsoleApp;
using Moq;
using ConsoleApp.moq;

namespace ConsoleApp.Test.moq
{
    public class HogeTest
    {
        private Mock<IHoge> hogeMock = new Mock<IHoge>();

        [Fact]
        public void Test1()
        {
            hogeMock.Setup(h => h.Calculate()).Returns(8);

            var f = new Fuga(hogeMock.Object);
            Assert.Equal(8, f.Calculate());
        }

        [Fact]
        public void Test2 ()
        {
            hogeMock.Setup(h => h.Calculate(It.IsAny<int>())).Returns(6);

            var f = new Fuga(hogeMock.Object);
            Assert.Equal(6, f.Calculate(1));
        }

        [Fact]
        public void Test3()
        {
            hogeMock.Setup(h => h.Calculate(It.IsAny<int>())).Throws<Exception>();

            var f = new Fuga(hogeMock.Object);
            try
            {
                f.Calculate(1);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            // 例外発生をテスト
            // Assert.Throws<Exception>(() => f.Calculate(1));
        }

    }
}
