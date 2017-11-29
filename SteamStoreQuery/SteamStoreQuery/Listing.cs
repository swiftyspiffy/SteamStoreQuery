using System.Globalization;
using SteamStoreQuery.Enums;

namespace SteamStoreQuery
{
    public class Listing
    {
        public string Name { get; protected set; }
        public string StoreLink { get; protected set; }
        public string ImageLink { get; protected set; }
        public double? Price { get; protected set; }
        public sType SaleType { get; protected set; }
        public int AppId { get; protected set; }

        public Listing(string listingData)
        {
            Name = listingData.Split('>')[2].Split('<')[0];
            StoreLink = listingData.Split('=')[2].Replace("\"", "").Split('?')[0];
            AppId = int.Parse(listingData.Split('=')[1].Replace("\"", "").Split(' ')[0]);
            ImageLink = listingData.Split('>')[4].Replace("\"", "").Split('=')[1];
            if (ImageLink.Contains("?"))
                ImageLink = ImageLink.Split('?')[0];
            string priceCandidate = listingData.Split('>')[7].Split('<')[0];
            if (priceCandidate == null || priceCandidate.Length < 2)
            {
                Price = null;
                SaleType = sType.NotAvailable;
            }
            else if(priceCandidate.ToLower().Contains("free"))
            {
                Price = null;
                SaleType = sType.FreeToPlay;
            }
            else
            {
                Price = double.Parse(priceCandidate.Replace("$", ""), CultureInfo.InvariantCulture);
                SaleType = sType.CostsMoney;
            }
        }
    }
}
