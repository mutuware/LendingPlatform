using Xunit;

namespace LendingPlatform.Tests
{
    public class ApplicationTests
    {
        [Theory]
        [InlineData(100_000, 250_000, 999)]
        [InlineData(1_100_000, 2_700_000, 999)]
        [InlineData(600_000, 1_000_000, 750)]
        [InlineData(800_000, 1_000_000, 800)]
        [InlineData(900_000, 1_000_000, 900)]

        public void Application_Successful(int loanAmount, int assetValue, int creditScore)
        { 
            // arrange
            var application = new Application(loanAmount, assetValue, creditScore);
            // assert
            Assert.True(application.IsSuccess);
        }

        [Theory]
        [InlineData(2_000_000, 250_000, 999)]
        [InlineData(90_000, 250_000, 999)]
        [InlineData(600_000, 1_000_000, 749)]
        [InlineData(800_000, 1_000_000, 799)]
        [InlineData(900_000, 1_000_000, 899)]
        public void Application_Fails(int loanAmount, int assetValue, int creditScore)
        {
            // arrange
            var application = new Application(loanAmount, assetValue, creditScore);
            // assert
            Assert.False(application.IsSuccess);
        }
    }
}
