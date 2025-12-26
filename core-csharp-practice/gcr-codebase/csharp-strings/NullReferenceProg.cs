using System;

class NullReferenceProg
{
    static void Main()
    {
        Console.Write("Enter a string (or leave empty for null): ");
        string? str = Console.ReadLine();                              // taking user input

        // Treat empty input as null
        if (string.IsNullOrEmpty(str))
            str = null;


        int? length = str?.Length;

        if (length != null)                                           // condition for output
        {
            Console.WriteLine("Length of the string: " + length);
        }
        else
        {
            Console.WriteLine("The string is null.");        
        }
    }
}
