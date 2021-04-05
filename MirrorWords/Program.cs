using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"@[A-Za-z]{3,}@@[A-Za-z]{3,}@|#[A-Za-z]{3,}##[A-Za-z]{3,}#");

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            Dictionary<string, string> output = new Dictionary<string, string>();

            foreach (var match in matches)
            {
                string word = match.ToString();

                if (word.Contains('@'))
                {
                    string[] parts = word.Split("@@");
                    string firstPart = parts[0];
                    string secondPart = parts[1];
                    string reversed = string.Empty;

                    for (int i = firstPart.Length - 1; i >= 0; i--)
                    {
                        reversed += firstPart[i];
                    }
                    if (reversed == secondPart)
                    {
                        firstPart = firstPart.Replace("@","");
                        secondPart = secondPart.Replace("@","");
                        output.Add(firstPart, secondPart);
                    }
                }
                else
                {
                    string[] parts = word.Split("##");
                    string firstPart = parts[0];
                    string secondPart = parts[1];
                    string reversed = string.Empty;

                    for (int i = firstPart.Length - 1; i >= 0; i--)
                    {
                        reversed += firstPart[i];
                    }
                    if (reversed == secondPart)
                    {
                        firstPart = firstPart.Replace("#", "");
                        secondPart = secondPart.Replace("#", "");
                        output.Add(firstPart, secondPart);
                    }
                }
            }
            
            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                if (output.Count==0)
                {
                    Console.WriteLine($"{matches.Count} word pairs found!");
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine($"{matches.Count} word pairs found!");
                    Console.WriteLine("The mirror words are:");

                }

                foreach (var item in output)
                {
                    if (!output[item.Key].Equals(output.Last().Value))
                    {
                        Console.Write($"{item.Key} <=> {item.Value}, ");
                    }
                    else
                    {
                        Console.Write($"{item.Key} <=> {item.Value}");
                    }
                }
            }
        }
    }
}
