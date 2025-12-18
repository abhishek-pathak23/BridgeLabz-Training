using System; 

class CelsiusToFahrenheitConversion
{
    static void Main()   
    {
        Console.Write("Enter temperature in Celsius: ");
        double celsius = Convert.ToDouble(Console.ReadLine()); // Read Celsius value

        double fahrenheit = (celsius * 9 / 5) + 32; // Conversion formula

        Console.WriteLine("Temperature In Fahrenheit = " + fahrenheit); // Output result
    }
}
