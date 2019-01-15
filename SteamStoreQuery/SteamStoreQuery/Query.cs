using System;
using System.Collections.Generic;
using System.Net;
using SteamStoreQuery.Enums;

namespace SteamStoreQuery
{
    public static class Query
    {
        public static List<Listing> Search(string gameName, string cc)
        {
            List<Listing> results = new List<Listing>();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string response = new WebClient().DownloadString($"https://store.steampowered.com/search/suggest?term={gameName}&f=games&cc={cc}&lang=english&v=2286217");
            if (!response.Contains("match ds_collapse_flag "))
                return results; 

            foreach (string s in response.Split(new string[] { "match ds_collapse_flag " }, StringSplitOptions.None))
                if(s.Contains("match_name") && s.Contains("match_price"))
                    results.Add(new Listing(s));

            return results;            
        }
    }
}
