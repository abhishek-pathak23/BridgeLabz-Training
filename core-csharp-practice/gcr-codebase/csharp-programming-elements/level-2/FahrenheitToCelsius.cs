using System;

class FahrenheitToCelsius
{
    public static void Main(string[] args)
    {
        double fahrenheit = Convert.ToDouble(Console.ReadLine());

        // Convert Fahrenheit to Celsius
        double celsiusResult = (fahrenheit - 32) * 5 / 9;

        Console.WriteLine(
            $"The {fahrenheit} Fahrenheit is {celsiusResult} Celsius"
        );
    }
}
