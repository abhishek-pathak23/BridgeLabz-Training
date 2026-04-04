using System;

class IndexOutOfRangeProg
{
    static void Main()
    {
        // Take string input from the user
        Console.Write("Enter a string: ");
        string str = Console.ReadLine()!; // Use ! because Console.ReadLine() can return null sometimes

        // Take index input from the user
        Console.Write("Enter an index to access: ");
        int index = Convert.ToInt32(Console.ReadLine());

        try
        {
            Console.WriteLine($"Character at index {index}: {str[index]}");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("Caught IndexOutOfRangeException: " + e.Message);
        }
    }
}
