using System;

class IntOperation
{
    public static void Main(string[] args)
    {
        int a, b, c;

        // Read integers a, b, and c from user input
        a = Convert.ToInt32(Console.ReadLine());
        b = Convert.ToInt32(Console.ReadLine());
        c = Convert.ToInt32(Console.ReadLine());

        // Perform integer operations considering operator precedence
        int result1 = a + b * c;
        int result2 = a * b + c; 
        int result3 = c + a / b; 
        int result4 = a % b + c; 

        // Display the results
        Console.WriteLine(
            $"The results of Int Operations are {result1}, {result2}, {result3}, and {result4}"
        );
    }
}
