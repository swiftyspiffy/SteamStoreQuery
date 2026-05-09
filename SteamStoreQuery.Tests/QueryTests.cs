using SteamStoreQuery;
using SteamStoreQuery.Enums;
using Xunit;
using System.Linq;
using System.Threading.Tasks;

namespace SteamStoreQuery.Tests
{
    public class QueryTests
    {
        [Fact]
        public void Search_ReturnsResults()
        {
            var results = Query.Search("counter strike");
            Assert.NotEmpty(results);
        }

        [Fact]
        public async Task SearchAsync_ReturnsResults()
        {
            var results = await Query.SearchAsync("counter strike");
            Assert.NotEmpty(results);
        }

        [Fact]
        public void Search_NoResults_ReturnsEmptyList()
        {
            var results = Query.Search("zzznonexistentgame999xyz");
            Assert.Empty(results);
        }

        [Fact]
        public async Task SearchAsync_NoResults_ReturnsEmptyList()
        {
            var results = await Query.SearchAsync("zzznonexistentgame999xyz");
            Assert.Empty(results);
        }

        [Fact]
        public void Search_ResultsHaveRequiredFields()
        {
            var results = Query.Search("dota");
            Assert.NotEmpty(results);

            var first = results[0];
            Assert.False(string.IsNullOrEmpty(first.Name));
            Assert.False(string.IsNullOrEmpty(first.AppId));
            Assert.False(string.IsNullOrEmpty(first.ImageLink));
        }

        [Fact]
        public void Search_CountryCodeWorks()
        {
            var results = Query.Search("half life", cc: "gb");
            Assert.NotEmpty(results);
        }

        [Fact]
        public void Search_FreeGame_DetectedCorrectly()
        {
            var results = Query.Search("counter strike 2");
            var freeGame = results.FirstOrDefault(r => r.SaleType == sType.FreeToPlay);
            Assert.NotNull(freeGame);
            Assert.Null(freeGame.Price);
        }

        [Fact]
        public void Search_PaidGame_HasPrice()
        {
            var results = Query.Search("counter strike");
            var paidGame = results.FirstOrDefault(r => r.SaleType == sType.CostsMoney);
            Assert.NotNull(paidGame);
            Assert.NotNull(paidGame.Price);
            Assert.True(paidGame.Price > 0);
        }
    }
}
