using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line=="Reveal")
                {
                    break;
                }

                string[] tokens = line.Split(":|:");
                string command = tokens[0];

                switch (command)
                {
                    case "InsertSpace":
                        int idx = int.Parse(tokens[1]);
                        message = message.Insert(idx, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        string substr = tokens[1];
                        string reversed = String.Empty;

                        if (message.Contains(substr))
                        {
                            idx = message.IndexOf(substr);
                            message = message.Remove(idx, substr.Length);
                            for (int i = substr.Length - 1; i >= 0; i--)
                            {
                                reversed += substr[i];
                            }
                            message = message + reversed;
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        substr = tokens[1];
                        string replacement = tokens[2];

                        while (message.Contains(substr))
                        {
                            message = message.Replace(substr,replacement);
                        }
                        Console.WriteLine(message);
                        break;
                }
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
