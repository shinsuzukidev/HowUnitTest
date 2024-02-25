using Xunit;
using ConsoleApp;

namespace ConsoleApp.Test
{
    public class PrimeService_Test
    {
        private readonly PrimeService _primeService;

        public PrimeService_Test()
        {
            _primeService = new PrimeService();        
        }

        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var primeService = new PrimeService();
            bool result = primeService.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }
    }
}