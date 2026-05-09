using System;
using System.Collections.Generic;
using SteamStoreQuery;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter Steam Store search query:");
            string searchQuery = Console.ReadLine();
            Console.WriteLine();

            List<Listing> results = Query.Search(searchQuery);

            Console.WriteLine($"Results: {results.Count}");
            Console.WriteLine("----------------");
            foreach (Listing result in results)
            {
                Console.WriteLine($"Name: {result.Name}");
                Console.WriteLine($"App ID: {result.AppId}");
                Console.WriteLine($"Store Link: {result.StoreLink}");
                Console.WriteLine($"Image Link: {result.ImageLink}");

                switch (result.SaleType)
                {
                    case SteamStoreQuery.Enums.sType.CostsMoney:
                        Console.WriteLine($"Price: ${result.Price}");
                        break;
                    case SteamStoreQuery.Enums.sType.FreeToPlay:
                        Console.WriteLine("Price: Free to Play");
                        break;
                    case SteamStoreQuery.Enums.sType.NotAvailable:
                        Console.WriteLine("Price: Not Available");
                        break;
                }
                Console.WriteLine("----------------");
            }
            Console.WriteLine();
        }
    }
}
