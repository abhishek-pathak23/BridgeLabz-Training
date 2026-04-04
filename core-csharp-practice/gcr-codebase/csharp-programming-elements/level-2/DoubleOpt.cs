using System;

class DoubleOpt
{
    public static void Main(string[] args)
    {
        double a, b, c;

        a = Convert.ToDouble(Console.ReadLine());
        b = Convert.ToDouble(Console.ReadLine());
        c = Convert.ToDouble(Console.ReadLine());

        double result1 = a + b * c;
        double result2 = a * b + c;
        double result3 = c + a / b;
        double result4 = a % b + c;

        Console.WriteLine(
            $"The results of Double Operations are {result1}, {result2}, {result3}, and {result4}"
        );
    }
}
