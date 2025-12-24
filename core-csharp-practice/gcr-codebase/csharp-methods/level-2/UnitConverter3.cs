using System;

class UnitConverter3
{
    // Temperature, weight, and volume conversions
    public static double ConvertFahrenheitToCelsius(double f) => (f - 32) * 5 / 9;
    public static double ConvertCelsiusToFahrenheit(double c) => (c * 9 / 5) + 32;
    public static double ConvertPoundsToKg(double p) => p * 0.453592;
    public static double ConvertKgToPounds(double kg) => kg * 2.20462;
    public static double ConvertGallonsToLiters(double g) => g * 3.78541;
    public static double ConvertLitersToGallons(double l) => l * 0.264172;

    static void Main()
    {
        Console.Write("Enter temperature in Fahrenheit: ");
        double f = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(f + " F = " + ConvertFahrenheitToCelsius(f) + " C");

        Console.Write("Enter temperature in Celsius: ");
        double c = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(c + " C = " + ConvertCelsiusToFahrenheit(c) + " F");

        Console.Write("Enter weight in pounds: ");
        double pounds = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(pounds + " lbs = " + ConvertPoundsToKg(pounds) + " kg");

        Console.Write("Enter weight in kilograms: ");
        double kg = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(kg + " kg = " + ConvertKgToPounds(kg) + " lbs");

        Console.Write("Enter volume in gallons: ");
        double gallons = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(gallons + " gallons = " + ConvertGallonsToLiters(gallons) + " liters");

        Console.Write("Enter volume in liters: ");
        double liters = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(liters + " liters = " + ConvertLitersToGallons(liters) + " gallons");
    }
}
