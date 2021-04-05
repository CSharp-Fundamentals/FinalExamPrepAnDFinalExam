using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedThree
{
    class Program
    {
        class Car
        {
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('|');
                string car = tokens[0];
                int mileage = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);

                cars.Add(car, new Car { Mileage = mileage, Fuel = fuel });
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    break;
                }

                string[] tokens = line.Split(" : ");
                string command = tokens[0];
                string car = tokens[1];

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(tokens[2]);
                        int fuel = int.Parse(tokens[3]);

                        if (cars[car].Fuel < fuel)
                        {
                            Console.WriteLine($"Not enough fuel to make that ride");
                        }
                        else
                        {
                            cars[car].Fuel -= fuel;
                            cars[car].Mileage += distance;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }

                        if (cars[car].Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            cars.Remove(car);
                        }
                        break;
                    case "Refuel":
                        fuel = int.Parse(tokens[2]);
                        cars[car].Fuel += fuel;

                        if (cars[car].Fuel > 75)
                        {
                            int fuelOver = cars[car].Fuel - 75;
                            int usedFuel = fuel - fuelOver;
                            cars[car].Fuel = 75;
                            Console.WriteLine($"{car} refueled with {usedFuel} liters");
                        }
                        else
                        {
                            Console.WriteLine($"{car} refueled with {fuel} liters");
                        }
                        break;
                    case "Revert":
                        distance = int.Parse(tokens[2]);
                        cars[car].Mileage -= distance;

                        if (cars[car].Mileage < 10000)
                        {
                            cars[car].Mileage = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{car} mileage decreased by {distance} kilometers");
                        }
                        break;
                }
            }
            Dictionary<string, Car> sorted = cars
                .OrderByDescending(c => c.Value.Mileage)
                .ThenBy(c => c.Key)
                .ToDictionary(c => c.Key, c => c.Value);

            foreach (var car in sorted)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}
