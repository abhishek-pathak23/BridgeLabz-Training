using System;

class CelsiusToFahrenheit
{
    public static void Main(string[] args)
    {
        double celsius = Convert.ToDouble(Console.ReadLine());

        // Convert Celsius to Fahrenheit
        double fahrenheitResult = (celsius * 9 / 5) + 32;

        Console.WriteLine(
            $"The {celsius} Celsius is {fahrenheitResult} Fahrenheit"
        );
    }
}
