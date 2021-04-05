using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicSeven
{
    class Program
    {
        class Heroes
        {
            public int Hp { get; set; }
            public int Mp { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Heroes> heroes = new Dictionary<string, Heroes>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int hp = int.Parse(tokens[1]);
                int mp = int.Parse(tokens[2]);

                if (hp>100)
                {
                    hp = 100;
                }
                if (mp>200)
                {
                    mp = 200;
                }
                heroes.Add(name, new Heroes { Hp = hp, Mp =mp});

            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] tokens = line.Split(" - ");
                string command = tokens[0];
                string heroName = tokens[1];

                switch (command)
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(tokens[2]);
                        string spellName = tokens[3];

                        if (heroes[heroName].Mp<mpNeeded)
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        else
                        {
                            heroes[heroName].Mp -= mpNeeded;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].Mp} MP!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(tokens[2]);
                        string attacker = tokens[3];
                        heroes[heroName].Hp -= damage;

                        if (heroes[heroName].Hp>0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].Hp} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroes.Remove(heroName);
                        }
                        break;
                    case "Recharge":
                        int amount = int.Parse(tokens[2]);
                        heroes[heroName].Mp += amount;

                        if (heroes[heroName].Mp>200)
                        {
                            int overLimitMp = heroes[heroName].Mp - 200;
                            int outputAmount = amount - overLimitMp;
                            Console.WriteLine($"{heroName} recharged for {outputAmount} MP!");
                            heroes[heroName].Mp = 200;
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} recharged for {amount} MP!");
                        }
                        break;
                    case "Heal":
                        amount = int.Parse(tokens[2]);
                        heroes[heroName].Hp += amount;

                        if (heroes[heroName].Hp > 100)
                        {
                            int overLimitHp = heroes[heroName].Hp - 100;
                            int outputAmount = amount - overLimitHp;
                            Console.WriteLine($"{heroName} healed for {outputAmount} HP!");
                            heroes[heroName].Hp = 100;
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} healed for {amount} HP!");
                        }
                        break;
                }
            }
            Dictionary<string,Heroes>sorted = heroes
                .OrderByDescending(h => h.Value.Hp)
                .ThenBy(h => h.Key)
                .ToDictionary(h => h.Key, h => h.Value);

            foreach (var item in sorted)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"  HP: {item.Value.Hp}");
                Console.WriteLine($"  MP: {item.Value.Mp}");
            }
        }
    }
}
