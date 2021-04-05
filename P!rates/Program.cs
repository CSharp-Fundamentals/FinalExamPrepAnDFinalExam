using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> goldByTown = new Dictionary<string, int>();
            Dictionary<string, int> populationByTown = new Dictionary<string, int>();


            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Sail")
                {
                    break;
                }
                string[] tokens = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);

                string townName = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);

                if (goldByTown.ContainsKey(townName))
                {
                    goldByTown[townName] += gold;
                    populationByTown[townName] += population;
                }
                else
                {
                    goldByTown.Add(townName, gold);
                    populationByTown.Add(townName, gold);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line=="End")
                {
                    break;
                }

                string[] tokens = line.Split("=>");
                string command = tokens[0];
                string townName = tokens[1];

                if (command=="Plunder")
                {
                    int people = int.Parse(tokens[2]);
                    int gold = int.Parse(tokens[3]);

                    goldByTown[townName] -= gold;
                    populationByTown[townName] -= people;

                    Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (goldByTown[townName] == 0 || populationByTown[townName] == 0)
                    {
                        goldByTown.Remove(townName);
                        populationByTown.Remove(townName);

                        Console.WriteLine($"{townName} has been wiped off the map!");
                    }
                }
                else if (command=="Prosper")
                {
                    int gold = int.Parse(tokens[2]);

                    if (gold<0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    goldByTown[townName] += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {gold} gold.");
                }
            }

            Dictionary<string, int> sorted = goldByTown
                .OrderByDescending(t => t.Value)
                .ThenBy(t => t.Key)
                .ToDictionary(x=>x.Key, x=>x.Value);

            if (sorted.Count==0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {sorted.Count} wealthy settlements to go to:");

                foreach (var kvp in sorted)
                {
                    string townName = kvp.Key;
                    int gold = kvp.Value;
                    int population = populationByTown[townName];
                    Console.WriteLine($"{townName} -> Population: {population} citizens, Gold: {gold} kg");
                }
            }
        }
    }
}
