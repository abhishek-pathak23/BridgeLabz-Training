using System;

class SimpleInterestCalc
{
    // Method for calculate simple interest
    public static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        return (principal * rate * time) / 100;
    }

    static void Main()
    {
        Console.Write("Enter Principal: ");
        double principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rate of Interest: ");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time: ");
        double time = Convert.ToDouble(Console.ReadLine());

        double interest = CalculateSimpleInterest(principal, rate, time);

        Console.WriteLine($"The Simple Interest is {interest} for the Principal {principal}, Rate of Interest is {rate} and Time {time} years");
    }
}
