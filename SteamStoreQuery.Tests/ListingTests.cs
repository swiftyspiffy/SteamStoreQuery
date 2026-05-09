using SteamStoreQuery;
using SteamStoreQuery.Enums;
using Xunit;

namespace SteamStoreQuery.Tests
{
    public class ListingTests
    {
        private const string PaidGameHtml =
            " data-ds-appid=\"10\" data-ds-itemkey=\"App_10\" data-ds-tagids=\"[19,1663]\" data-ds-descids=\"[2,5]\" data-ds-crtrids=\"[4]\" " +
            "href=\"https://store.steampowered.com/app/10/CounterStrike/?snr=1_7_15__13\">" +
            "<div class=\"match_name\">Counter-Strike</div>" +
            "<div class=\"match_img\"><img src=\"https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/10/capsule_sm_120.jpg?t=1745368572\"></div>" +
            "<div class=\"match_price\">$9.99</div></a>";

        private const string FreeGameHtml =
            " data-ds-appid=\"730\" data-ds-itemkey=\"App_730\" data-ds-tagids=\"[1663,1774]\" data-ds-descids=\"[2,5]\" data-ds-crtrids=\"[4]\" " +
            "href=\"https://store.steampowered.com/app/730/CounterStrike_2/?snr=1_7_15__13\">" +
            "<div class=\"match_name\">Counter-Strike 2</div>" +
            "<div class=\"match_img\"><img src=\"https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/730/capsule_sm_120.jpg?t=1749053861\"></div>" +
            "<div class=\"match_price\">Free To Play</div></a>";

        private const string NoTagIdsHtml =
            " data-ds-appid=\"2678630\" data-ds-itemkey=\"App_2678630\" " +
            "href=\"https://store.steampowered.com/app/2678630/Test/?snr=1_7_15__13\">" +
            "<div class=\"match_name\">Some Game</div>" +
            "<div class=\"match_img\"><img src=\"https://example.com/img.jpg\"></div>" +
            "<div class=\"match_price\">$4.99</div></a>";

        [Fact]
        public void PaidGame_ParsesName()
        {
            var listing = new Listing(PaidGameHtml);
            Assert.Equal("Counter-Strike", listing.Name);
        }

        [Fact]
        public void PaidGame_ParsesAppId()
        {
            var listing = new Listing(PaidGameHtml);
            Assert.Equal("10", listing.AppId);
        }

        [Fact]
        public void PaidGame_ParsesPrice()
        {
            var listing = new Listing(PaidGameHtml);
            Assert.Equal(9.99, listing.Price);
        }

        [Fact]
        public void PaidGame_SaleTypeIsCostsMoney()
        {
            var listing = new Listing(PaidGameHtml);
            Assert.Equal(sType.CostsMoney, listing.SaleType);
        }

        [Fact]
        public void PaidGame_ParsesStoreLink()
        {
            var listing = new Listing(PaidGameHtml);
            Assert.Equal("https://store.steampowered.com/app/10/CounterStrike", listing.StoreLink);
        }

        [Fact]
        public void PaidGame_ParsesImageLink()
        {
            var listing = new Listing(PaidGameHtml);
            Assert.Equal("https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/10/capsule_sm_120.jpg", listing.ImageLink);
        }

        [Fact]
        public void FreeGame_ParsesName()
        {
            var listing = new Listing(FreeGameHtml);
            Assert.Equal("Counter-Strike 2", listing.Name);
        }

        [Fact]
        public void FreeGame_SaleTypeIsFreeToPlay()
        {
            var listing = new Listing(FreeGameHtml);
            Assert.Equal(sType.FreeToPlay, listing.SaleType);
        }

        [Fact]
        public void FreeGame_PriceIsNull()
        {
            var listing = new Listing(FreeGameHtml);
            Assert.Null(listing.Price);
        }

        [Fact]
        public void FreeGame_ParsesAppId()
        {
            var listing = new Listing(FreeGameHtml);
            Assert.Equal("730", listing.AppId);
        }

        [Fact]
        public void MissingTagIds_StoreLinkHandledGracefully()
        {
            var listing = new Listing(NoTagIdsHtml);
            Assert.Equal("", listing.StoreLink);
        }
    }
}
