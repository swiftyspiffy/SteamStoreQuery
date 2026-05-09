using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamStoreQuery
{
    public static class Query
    {
        private static readonly string suggestEndpoint = "https://store.steampowered.com/search/suggest";
        private static readonly HttpClient client = new HttpClient();

        public static List<Listing> Search(string gameName, string cc = "us")
        {
            return SearchAsync(gameName, cc).GetAwaiter().GetResult();
        }

        public static async Task<List<Listing>> SearchAsync(string gameName, string cc = "us")
        {
            var results = new List<Listing>();
            string response = await client.GetStringAsync(
                $"{suggestEndpoint}?term={Uri.EscapeDataString(gameName)}&f=games&cc={Uri.EscapeDataString(cc)}&lang=english");

            if (!response.Contains("match ds_collapse_flag "))
                return results;

            foreach (string s in response.Split(new string[] { "match ds_collapse_flag " }, StringSplitOptions.None))
                if (s.Contains("match_name") && s.Contains("match_price"))
                    results.Add(new Listing(s));

            return results;
        }
    }
}
