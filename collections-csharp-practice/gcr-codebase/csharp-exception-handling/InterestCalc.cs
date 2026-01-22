using System;

class InterestCalc
{
    static double Calc(double amt, double rate, int yrs)
    {
        if (amt < 0 || rate < 0)
            throw new ArgumentException("Amount and rate must be positive.");
        return amt * rate * yrs / 100;
    }

    static void Main()
    {
        try
        {
            Console.Write("Amount: ");
            double amt = double.Parse(Console.ReadLine());
            Console.Write("Rate: ");
            double rate = double.Parse(Console.ReadLine());
            Console.Write("Years: ");
            int yrs = int.Parse(Console.ReadLine());

            Console.WriteLine("Interest: " + Calc(amt, rate, yrs));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Invalid input: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input!");
        }
    }
}
