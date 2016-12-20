using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamStoreQuery;

namespace SteamStoreQueryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Insert search query: ");
                string searchQuery = Console.ReadLine();

                Console.WriteLine();

                Console.WriteLine("Results:");
                List<Listing> results = Query.Search(searchQuery);
                foreach (Listing result in results)
                    Console.WriteLine($"Name: {result.Name}\nStore Link: {result.StoreLink}\nApp Id: {result.AppId}\nImage Link: {result.ImageLink}\nPrice (USD): {result.PriceUSD}\n\n");
                Console.WriteLine("------Request Ended!------\n");
            }
            
        }
    }
}
