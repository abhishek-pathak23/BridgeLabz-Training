using System;

class SwapNumbers
{
    public static void Main(string[] args)
    {
        double number1 = Convert.ToDouble(Console.ReadLine());
        double number2 = Convert.ToDouble(Console.ReadLine());

        // Swap numbers
        double temp = number1;
        number1 = number2;
        number2 = temp;

        Console.WriteLine(
            $"The swapped numbers are {number1} and {number2}"
        );
    }
}
