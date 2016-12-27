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
                {
                    switch(result.SaleType)
                    {
                        case Listing.sType.CostsMoney:
                            Console.WriteLine($"Name: {result.Name}\nStore Link: {result.StoreLink}\nApp Id: {result.AppId}\nImage Link: {result.ImageLink}\nPrice (USD): {result.PriceUSD}\n\n");
                            break;

                        case Listing.sType.FreeToPlay:
                            Console.WriteLine($"Name: {result.Name}\nStore Link: {result.StoreLink}\nApp Id: {result.AppId}\nImage Link: {result.ImageLink}\nPrice (USD): Free to Play!\n\n");
                            break;

                        case Listing.sType.NotAvailable:
                            Console.WriteLine($"Name: {result.Name}\nStore Link: {result.StoreLink}\nApp Id: {result.AppId}\nImage Link: {result.ImageLink}\nPrice (USD): Not Available!\n\n");
                            break;
                    }
                }
                    
                Console.WriteLine("------Request Ended!------\n");
            }
            
        }
    }
}
