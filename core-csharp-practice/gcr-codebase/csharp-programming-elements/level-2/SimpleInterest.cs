using System;

class SimpleInterest
{
    public static void Main(string[] args)
    {
        // Input principal, rate, and time
        double principal = Convert.ToDouble(Console.ReadLine());
        double rate = Convert.ToDouble(Console.ReadLine());
        double time = Convert.ToDouble(Console.ReadLine());

        // Calculate simple interest
        double interest = (principal * rate * time) / 100;

        // Display result
        Console.WriteLine(
            $"The Simple Interest is {interest} for Principal {principal}, Rate of Interest {rate} and Time {time}"
        );
    }
}
