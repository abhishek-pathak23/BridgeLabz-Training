using System;

class TotalIncome
{
    public static void Main(string[] args)
    {
        double salary = Convert.ToDouble(Console.ReadLine());
        double bonus = Convert.ToDouble(Console.ReadLine());

        double totalIncome = salary + bonus; // Calculating total income

        Console.WriteLine(
            $"The salary is INR {salary} and bonus is INR {bonus}. Hence Total Income is INR {totalIncome}"
        );
    }
}
