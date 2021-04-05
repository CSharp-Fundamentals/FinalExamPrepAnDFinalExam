using System;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line=="Done")
                {
                    break;
                }

                string[] tokens = line.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "TakeOdd":
                        string result = String.Empty;
                        for (int i = 1; i < password.Length; i+=2)
                        {
                            result += password[i];
                        }
                        password = result;
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);
                        password = password.Remove(index, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string substring = tokens[1];
                        string substitute = tokens[2];

                        if (password.Contains(substring))
                        {
                            password=password.Replace(substring,substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
