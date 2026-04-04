using System;

class WindChillTempCalc
{
    // Calculating wind chill temperature 
    public static double GetWindChill(double airTemperature, double windVelocity)
    {
        double windFactor = Math.Pow(windVelocity, 0.16);

        double windChillValue =
            35.74 +
            (0.6215 * airTemperature) +
            ((0.4275 * airTemperature - 35.75) * windFactor);

        return windChillValue;
    }

    static void Main()
    {
        Console.Write("Enter air temperature: ");
        double airTemperature = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter wind speed: ");
        double windVelocity = Convert.ToDouble(Console.ReadLine());

        double result = GetWindChill(airTemperature, windVelocity);

        Console.WriteLine("Wind Chill Temperature: " + result);
    }
}
