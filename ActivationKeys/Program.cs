using System;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = String.Empty;

            while ((command=Console.ReadLine()) != "Generate")
            {
                string[] token = command.Split(">>>",StringSplitOptions.RemoveEmptyEntries);

                switch (token[0])
                {
                    case "Contains":
                        if (activationKey.Contains(token[1]))
                        {
                            Console.WriteLine($"{activationKey} contains {token[1]}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string casing = token[1];
                        int startIdx = int.Parse(token[2]);
                        int endIdx = int.Parse(token[3]);

                        string substring = activationKey.Substring(startIdx, endIdx - startIdx);
                        string replacement = casing == "Upper"
                            ? substring.ToUpper()
                            : substring.ToLower();

                        activationKey = activationKey.Replace(substring, replacement);
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        int start = int.Parse(token[1]);
                        int end = int.Parse(token[2]);

                        activationKey = activationKey.Remove(start,end-start);
                        Console.WriteLine(activationKey);
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
