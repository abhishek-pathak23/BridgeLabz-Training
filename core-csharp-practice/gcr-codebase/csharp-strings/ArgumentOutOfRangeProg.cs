using System;

class ArgumentOutOfRangeProg
{
    static void Main()
    {
        // Take string input from the user
        Console.Write("Enter a string: ");
        string str = Console.ReadLine()!; 

        // Take start index input
        Console.Write("Enter the start index: ");
        int startIndex = Convert.ToInt32(Console.ReadLine());

        // Take length input
        Console.Write("Enter the length of substring: ");
        int length = Convert.ToInt32(Console.ReadLine());

        try
        {
            string result = str.Substring(startIndex, length);
            Console.WriteLine("Substring: " + result);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Caught ArgumentOutOfRangeException: " + e.Message); // Output message
        }
    }
}
