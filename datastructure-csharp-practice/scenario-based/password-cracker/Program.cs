using System;

namespace PasswordCracker
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- Password Cracker Simulator ---");
                Console.WriteLine("1. Generate all combinations");
                Console.WriteLine("2. Crack password");
                Console.WriteLine("3. View complexity");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("Enter password length: ");
                        int length = int.Parse(Console.ReadLine());

                        // Interface reference for generator
                        IPasswordOperation generator =
                            new PasswordGenerator(length);
                        generator.Execute();
                        break;

                    case 2:
                        Console.Write("Enter target password: ");
                        string secret = Console.ReadLine();

                        // Interface reference for matcher
                        IPasswordOperation matcher =
                            new PasswordMatcher(secret);
                        matcher.Execute();
                        break;

                    case 3:
                        ComplexityUtil.Show();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
