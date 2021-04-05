using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamThirdProblem
{
    class Program
    {
        class Message
        {
            public int Sent { get; set; }
            public int Received { get; set; }
        }
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Dictionary<string, Message> info = new Dictionary<string, Message>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line=="Statistics")
                {
                    break;
                }

                string[] tokens = line.Split('=',StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command)
                {
                    case "Add":
                        string username = tokens[1];
                        int sent = int.Parse(tokens[2]);
                        int received = int.Parse(tokens[3]);

                        if (info.ContainsKey(username))
                        {
                            continue;
                        }
                        else
                        {
                            info.Add(username,new Message { Sent=sent,Received=received});
                        }
                        break;
                    case "Message":
                        string sender = tokens[1];
                        string receiver = tokens[2];

                        if (info.ContainsKey(sender) && info.ContainsKey(receiver))
                        {
                            info[sender].Sent++;
                            info[receiver].Received++;

                            if ((info[sender].Sent+ info[sender].Received) >= capacity)
                            {
                                Console.WriteLine($"{sender} reached the capacity!");
                                info.Remove(sender);
                            }
                            if ((info[receiver].Received+ info[receiver].Sent) >= capacity)
                            {
                                Console.WriteLine($"{receiver} reached the capacity!");
                                info.Remove(receiver);
                            }
                        }
                        break;
                    case "Empty":
                        username = tokens[1];

                        if (username!="All")
                        {
                            info.Remove(username);
                        }
                        else
                        {
                           info = new Dictionary<string, Message>();
                        }
                        break;
                }
            }

            Dictionary<string, Message> sorted = info
                .OrderByDescending(m => m.Value.Received)
                .ThenBy(m => m.Key)
                .ToDictionary(m=>m.Key,m=>m.Value);

            Console.WriteLine($"Users count: {sorted.Count}");

            foreach (var user in sorted)
            {
                Console.WriteLine($"{user.Key} - {user.Value.Sent + user.Value.Received}");
            }
        }
    }
}
