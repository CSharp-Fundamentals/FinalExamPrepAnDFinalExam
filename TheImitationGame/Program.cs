using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] tokens = command.Split('|',StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Move":
                        int charactersCount = int.Parse(tokens[1]);
                        string charachters = message.Substring(0, charactersCount);
                        message = message.Substring(charactersCount)+charachters;
                        break;

                    case "Insert":
                        int index = int.Parse(tokens[1]);
                        message = message.Insert(index, tokens[2]);
                        break;
                    case "ChangeAll":
                        while (message.Contains(tokens[1]))
                        {
                            message = message.Replace(tokens[1],tokens[2]);
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}

