using System;
using System.Text;

class StringConcatenationTest
{
    static void Main()
    {
        int count = 10000;

       
        // Using string (Inefficient)
        string normalString = "";

        for (int i = 0; i < count; i++)
        {
            // Each '+' creates a NEW string object
            normalString = normalString + "A";
        }

        Console.WriteLine("String concatenation completed.");
        // Using StringBuilder (Efficient)
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < count; i++)
        {
            // Append modifies the same object
            builder.Append("A");
        }

        Console.WriteLine("StringBuilder concatenation completed.");
    }
}
