using System;
using System.Globalization;

class DateArithmeticProg
{
    // Method performs all date calculations
    static DateTime PerformDateOperations(DateTime inputDate)
    {
        DateTime updatedDate = inputDate
                                .AddDays(7)
                                .AddMonths(1)
                                .AddYears(2)
                                .AddDays(-21); // subtracting 3 weeks 

        return updatedDate;              // giving the updated date
    }

    static void Main()
    {
        Console.Write("Enter date (dd-MM-yyyy): "); 
        string input = Console.ReadLine()!;                  // taking the input

        DateTime date = DateTime.ParseExact(
            input,
            "dd-MM-yyyy",
            CultureInfo.InvariantCulture
        );

        DateTime result = PerformDateOperations(date);
        Console.WriteLine("Final Date After Calculations: " + result.ToString("dd-MM-yyyy"));             //Output as final date
    }
}
