using System;
using System.Text.RegularExpressions;

namespace FinalExamProblemTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"!(?<command>[A-Z][a-z]{2,})!:\[(?<toEncrypt>[A-Za-z]{8,})]");

            int n =int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                Match match = regex.Match(message);

                if (!match.Success)
                {
                    Console.WriteLine("The message is invalid");
                }
                else
                {
                    string command = match.Groups["command"].Value;
                    string toEncrypt = match.Groups["toEncrypt"].Value;
                    int asciiNum = 0;

                    Console.Write($"{command}: ");

                    for (int j = 0; j < toEncrypt.Length; j++)
                    {
                        asciiNum = (int)(toEncrypt[j]);
                        Console.Write($"{asciiNum} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
