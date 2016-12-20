# SteamStoreQuery - C# Steam Store Search Library
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/SteamStoreQuery.svg)](https://www.nuget.org/packages/SteamStoreQuery)
### Overview
SteamStoreQuery is a simple library that allows you to search the Steam store and get listings for related games, including their price (USD), name, store link, image link, and app id.

### Sample Implementation
Below is an example of how to use the library. Included in the project is also a Test applicaiton.
```
using SteamStoreQuery;

string searchQuery = "call of duty";
List<Listing> results = Query.Search(searchQuery);
Console.WriteLine($"The first result is {results[0].Name}, and it costs ${results[0].PriceUSD}. You can find it here: {results[0].StoreLink}");
Console.ReadLine();
```
Results:
```
The first result is Call of Duty: World at War, and it costs $19.99. You can find it here: http://store.steampowered.com/app/10090/
```

### Availability
Available via Nuget: `Install-Package SteamStoreQuery`
 
### License
MIT License. &copy; 2016 Cole
