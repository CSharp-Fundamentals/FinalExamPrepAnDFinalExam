using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(=|\/)(?<location>[A-Z][A-Za-z]{2,})\1");
            List<string> output = new List<string>();
            string destinations = Console.ReadLine();

            MatchCollection matches = regex.Matches(destinations);
            int travelPoints = 0;

            foreach (var match in matches)
            {
                string dest = match.ToString().Replace("=", "").Replace("/", "");
                travelPoints += dest.Length;
                output.Add(dest);
            }
            Console.WriteLine($"Destinations: {string.Join(", ", output)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}