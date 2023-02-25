using System;
using System.Text.RegularExpressions;
namespace Valid_Address
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // A dictionary of regular expressions for different digital currencies
                var regexDictionary = new System.Collections.Generic.Dictionary<string, string>()
            {
                { "Bitcoin", @"^(bc1|[13])[a-zA-HJ-NP-Z0-9]{25,39}$" },
                { "Ethereum", @"^0x[a-fA-F0-9]{40}$" },
                { "Litecoin", @"^(ltc|LTC)[a-zA-HJ-NP-Z0-9]{25,34}$" },
                { "NEO", @"^A[a-zA-HJ-NP-Z0-9]{33}$" },
                 { "Polkadot", @"^1[a-zA-HJ-NP-Z0-9]{25,39}$" },
                 { "Cardano", @"^addr1[0-9a-zA-Z]{38,99}$" },
                 { "Cardano2", @"^Ddz[0-9a-zA-Z]{83}$" },
                 { "Dogecoin", @"^(D|A)[a-km-zA-HJ-NP-Z1-9]{25,34}$" },
                { "Tron", @"^T[a-zA-HJ-NP-Z0-9]{33}$" },
                { "XRP", @"^r[0-9a-zA-Z]{24,34}$" },
                { "ICON", @"^hx[0-9a-fA-F]{40}$" },
                { "Stellar", @"^G[a-zA-Z0-9]{55}$" },
                { "IOTA", @"^IOTA[A-Z0-9]{57}$" },
                { "Atom", @"^cosmos1[a-zA-HJ-NP-Z0-9]{38}$" },
                { "AVAX", @"^(X-)?[A-Za-z0-9]{34}$" },
                { "SOL", @"^s[0-9a-zA-Z]{32,}$" },
                { "QTUM", @"^Q[0-9a-zA-Z]{41}$" },
                { "THETA", @"^0x[0-9a-fA-F]{40}$" },
                { "DAI", @"^0x[0-9a-fA-F]{40}$" },
                { "XMR", @"^4[0-9AB][1-9A-HJ-NP-Za-km-z]{93}$" },
                { "LINK", @"^0x[0-9a-fA-F]{40}$" },
                { "ALGO", @"^[A-Z2-7]{58}$" },
                {"XTZ", @"^tz[1-9A-HJ-NP-Za-km-z]{33}$"},
                {"XEM", @"^N[A-Z2-7]{39}$"},
                {"KSM", @"^F[0-9a-zA-Z]{47}$"},
                {"ONT", @"^A[0-9a-zA-Z]{33}$"},
                {"NEAR", @"^(([a-z\d]+(-[a-z\d]+)*)\.)*[a-z\d]+(-[a-z\d]+)*@([a-z\d]+(-[a-z\d]+)*\.)+[a-z]{2,}$"},
                {"BAND", @"^band1[qpzry9x8gf2tvdw0s3jn54khce6mua7l]{39}$"},
                {"ZIL", @"^zil1[qpzry9x8gf2tvdw0s3jn54khce6mua7l]{39}$"},
                { "NANO", @"^nano_[13456789abcdefghijkmnopqrstuwxyz]{60}$" },
                { "Hedera Hashgraph", @"^0x[0-9a-fA-F]{40}$" },
                { "Bitcoin Cash", @"^(bitcoincash:)?(q|p)[a-zA-HJ-NP-Z0-9]{41}$" },
                { "Binance Smart Chain", @"^(0x[a-fA-F0-9]{40})|(bnb1[a-zA-HJ-NP-Z0-9]{38})|(bnb12[a-zA-HJ-NP-Z0-9]{36})|(bnb1p[a-zA-HJ-NP-Z0-9]{38})$" },

                // Add regex patterns for other digital currencies here
            };

                // Get the user input for the digital currency address
                Console.WriteLine("Enter the digital currency address to validate:");
                string address = Console.ReadLine().Trim();

                // Check if the address matches the regex pattern for any digital currency
                bool isValid = false;
                string matchedCurrency = "";
                foreach (var regexPattern in regexDictionary)
                {
                    if (Regex.IsMatch(address, regexPattern.Value))
                    {
                        isValid = true;
                        matchedCurrency = regexPattern.Key;
                        break;
                    }
                }

                // Output the result of the validation
                if (isValid)
                {
                    Console.WriteLine($"The {matchedCurrency} address '{address}' is valid.");
                }
                else
                {
                    Console.WriteLine("The address is not valid.");
                }

                // Wait for user input before closing the program
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

            }
        }
    }
}
