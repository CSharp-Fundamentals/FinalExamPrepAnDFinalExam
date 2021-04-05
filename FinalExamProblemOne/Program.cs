using System;

namespace FinalExamProblemOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line=="End")
                {
                    break;
                }

                string[] tokens = line.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Translate":
                        char letter = char.Parse(tokens[1]);
                        char replacement = char.Parse(tokens[2]);

                        if (text.Contains(letter))
                        {
                            text = text.Replace(letter,replacement);
                        }
                        Console.WriteLine(text);
                        break;
                    case "Includes":
                        string substr = tokens[1];

                        if (text.Contains(substr))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Start":
                        substr = tokens[1];
                        bool isEqual = true;
                        for (int i = 0; i < substr.Length; i++)
                        {
                            if (text[i]!=substr[i])
                            {
                                isEqual = false;
                            }
                        }
                        if (isEqual)
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Lowercase":
                        text = text.ToLower();
                        Console.WriteLine(text);
                        break;
                    case "FindIndex":
                        letter = char.Parse(tokens[1]);
                        int idx = text.LastIndexOf(letter);
                        Console.WriteLine(idx);
                        break;
                    case "Remove":
                        int startIndex = int.Parse(tokens[1]);
                        int count = int.Parse(tokens[2]);
                        text = text.Remove(startIndex,count);
                        Console.WriteLine(text);
                        break;
                }
            }
        }
    }
}
