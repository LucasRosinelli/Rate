# Rate

This project was created to show my skills using .NET Core to deliver the rate between a pair of currencies.

## Problem

Write a .NET Core Console application that uses the contents of the XML file at https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml and expose an HTTP endpoint to retrieve the rate for a specific currency pair. So a GET request to http://localhost:port/rate?currencypair=GBPUSD should return the rate to convert GBP to USD. The rates should be cached for one hour so we don’t download the file with every request.

## Installing

```
Clone the project
```

Open the solution file in Visual Studio 2017

Set LucasRosinelli.Rate.Api as your startup project and press "IIS Express" button. The API will run on

```
http://localhost:50635/
```

You can ignore the initial page.

To execute on browser, type on address bar:

```
http://localhost:50635/rate?currencyPair=GBPUSD
```

If you prefer, you can use Postman(https://www.getpostman.com/) to GET the rate. NOTE: cache feature will works only if "Send no-cache header" is disabled. For more information: (https://www.getpostman.com/docs/v6/postman/launching_postman/settings)

To create the executable file for Win-x64 / Windows 10 machine, go to LucasRosinelli.Rate.Presentation.Console folder in "Command Prompt" and type:

```
dotnet publish -c Release -r win10-x64
```

## Documentation
You will find in each files its own documentation

## Design patterns used
* Unit of work
* Repository pattern
* Dependency injection

## Built With

* Visual Studio 2017(https://visualstudio.microsoft.com/)
* ASP.NET Core 2.1.202(https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.1)

## Author

* Lucas Rosinelli da Rocha(http://lucasrosinelli.com/)
* LinkedIn(https://www.linkedin.com/in/lucasrosinelli/)