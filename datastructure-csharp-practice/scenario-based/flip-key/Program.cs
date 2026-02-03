using System;
using CleanseTool.Services;

namespace CleanseTool
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Generate Key");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter the word: ");
                    string input = Console.ReadLine();

                    StringProcessor processor = new StringProcessor();
                    string result = processor.CleanseAndInvert(input);

                    if (string.IsNullOrEmpty(result))
                        Console.WriteLine("Invalid Input");
                    else
                        Console.WriteLine("The generated key is - " + result);
                }
                else if (choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }
    }
}
