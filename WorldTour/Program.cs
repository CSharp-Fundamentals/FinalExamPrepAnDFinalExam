using System;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Travel")
                {
                    break;
                }

                string[] tokens = line.Split(":");
                string command = tokens[0];

                switch (command)
                {
                    case "Add Stop":
                        int idx = int.Parse(tokens[1]);
                        string substr = tokens[2];

                        if (idx >= 0 && idx < destination.Length)
                        {
                            destination = destination.Insert(idx, substr);
                        }
                        Console.WriteLine(destination);
                        break;

                    case "Remove Stop":
                        int startIdx = int.Parse(tokens[1]);
                        int endIdx = int.Parse(tokens[2]);

                        if (startIdx >= 0 && endIdx>=0 && endIdx<=destination.Length-1)
                        {
                            destination = destination.Remove(startIdx, endIdx - startIdx + 1);
                        }
                        Console.WriteLine(destination);
                        break;

                    case "Switch":
                        string oldString = tokens[1];
                        string newString = tokens[2];

                        if (destination.Contains(oldString))
                        {
                            destination = destination.Replace(oldString, newString);
                        }
                        Console.WriteLine(destination);
                        break;
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {destination}");
        }
    }
}
