using System;

class PowerOfNumber
{
    static void Main()
    {
        int number, power;   // Initialize variables
        int result = 1;

        Console.WriteLine("Enter number:");
        number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter power:");
        power = Convert.ToInt32(Console.ReadLine());

        // Calculate the power
        for (int i = 1; i <= power; i++)
        {
            result = result * number;
        }

        Console.WriteLine("Result is " + result);
    }
}
