using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(::|\*\*)[A-Z][a-z]{2,}\1");
            Regex threshold = new Regex(@"\d");

            MatchCollection matches = regex.Matches(input);
            MatchCollection numberMatches = threshold.Matches(input);
            int sum = 0;
            long thresholdSum = 1;

            foreach (var digit in numberMatches)
            {
                thresholdSum *= long.Parse(digit.ToString());
            }

            Console.WriteLine($"Cool threshold: {thresholdSum}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            
            foreach (Match match in matches)
            {
                foreach (char letter in match.Value)
                {
                    if (Char.IsLetter(letter))
                    {
                        sum += letter;
                    }
                }
                if (sum > thresholdSum)
                {
                    Console.WriteLine(match.Value);
                }
                sum = 0;
            }
        }
    }
}
