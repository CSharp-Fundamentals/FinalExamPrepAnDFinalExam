using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Program
    {
         static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

                for (int i = 1; i <= n; i++)
                {
                    string input = Console.ReadLine();
                    string[] info = input.Split("<->");
                    string plantName = info[0];
                    int rarity = int.Parse(info[1]);

                    if (!plants.ContainsKey(plantName))
                    {
                        Plant plant = new Plant(rarity);
                        plants.Add(plantName, plant);
                    }
                    else
                    {
                        plants[plantName].Rarity = rarity;
                    }
                }
                string secondInput = Console.ReadLine();
                while (secondInput != "Exhibition")
                {
                    string[] info = secondInput.Split();
                    string plantName = info[1];

                    if (secondInput.Contains("Rate"))
                    {
                        int rating = int.Parse(info[3]);
                        plants[plantName].Rating.Add(rating);
                    }
                    else if (secondInput.Contains("Update"))
                    {
                        int rarity = int.Parse(info[3]);
                        plants[plantName].Rarity = rarity;
                    }
                    else if (secondInput.Contains("Reset"))
                    {
                        plants[plantName].Rating = new List<int>(){
                        0 };
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    secondInput = Console.ReadLine();
                }
                var sortedPlants = plants.OrderByDescending(x => x.Value.Rarity)
                    .ThenByDescending(x => x.Value.Rating.Average());
                Console.WriteLine("Plants for the exhibition:");

                foreach (var item in sortedPlants)
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; " +
                        $"Rating: {item.Value.Rating.Average():f2}");
                }
            }

        public class Plant
        {
            public int Rarity { get; set; }
            public List<int> Rating;

            public Plant(int rarity)
            {
                this.Rarity = rarity;
                Rating = new List<int>();
            }
        }
    }
}