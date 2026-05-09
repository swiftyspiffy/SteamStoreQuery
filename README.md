# SteamStoreQuery - C# Steam Store Search Library
[![NuGet](https://img.shields.io/nuget/vpre/SteamStoreQuery.svg)](https://www.nuget.org/packages/SteamStoreQuery)

### Overview
SteamStoreQuery is a simple library that allows you to search the Steam store and get listings for related games, including their price, name, store link, image link, and app id. Supports both sync and async calls.

**Note:** This library uses an undocumented Steam endpoint and may break if Valve changes their markup.

### Usage
```csharp
using SteamStoreQuery;

// Synchronous
var results = Query.Search("counter strike");

// Async
var results = await Query.SearchAsync("half life");

// With country code
var results = Query.Search("portal", cc: "gb");

// Access result properties
foreach (var listing in results)
{
    Console.WriteLine($"{listing.Name} - ${listing.Price} - {listing.StoreLink}");
}
```

### Listing Properties
| Property | Type | Description |
|----------|------|-------------|
| `Name` | `string` | Game title |
| `AppId` | `string` | Steam app ID |
| `Price` | `double?` | Price in local currency (null if free or unavailable) |
| `SaleType` | `sType` | `CostsMoney`, `FreeToPlay`, or `NotAvailable` |
| `StoreLink` | `string` | URL to the Steam store page |
| `ImageLink` | `string` | URL to the game's capsule image |

### Install
```
dotnet add package SteamStoreQuery
```

### License
MIT License. Copyright 2016 Cole
