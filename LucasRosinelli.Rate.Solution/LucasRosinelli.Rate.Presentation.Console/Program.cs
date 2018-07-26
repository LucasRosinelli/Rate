using System;
using System.Net.Http;

namespace LucasRosinelli.Rate.Presentation.Console
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            var exit = false;

            do
            {
                System.Console.WriteLine("Inform the currency pair (type 'exit' or 'quit' to leave): ");
                var currencyPair = System.Console.ReadLine();

                if (currencyPair.Equals("exit", StringComparison.InvariantCultureIgnoreCase) ||
                    currencyPair.Equals("quit", StringComparison.InvariantCultureIgnoreCase))
                {
                    exit = true;
                }
                else
                {
                    ProcessRepositories(currencyPair);
                }
            } while (!exit);
        }

        private static void ProcessRepositories(string currencyPair)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("User-Agent", "Lucas Rosinelli Rate Presentation Console");

                var result = client.GetStringAsync(string.Concat("http://localhost:50635/rate?currencyPair=", currencyPair)).Result;

                System.Console.WriteLine(result);
            }
            catch (Exception exc)
            {
                System.Console.WriteLine(string.Concat("Error getting rate for ", currencyPair, Environment.NewLine, "Details:\tMessage:", exc.Message));
            }
        }
    }
}