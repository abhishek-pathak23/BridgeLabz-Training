using System;
using System.Globalization;

class DateComparisonProg
{
    // Method compares two dates
    static void CompareDates(DateTime firstDate, DateTime secondDate)
    {
        if (firstDate < secondDate)
            Console.WriteLine("First date is before second date");
        else if (firstDate > secondDate)
            Console.WriteLine("First date is after second date");
        else
            Console.WriteLine("Both dates are the same");
    }

    static void Main()
    {
        Console.Write("Enter first date (dd-MM-yyyy): ");
        string input1 = Console.ReadLine()!;                        // Taking input

        Console.Write("Enter second date (dd-MM-yyyy): ");
        string input2 = Console.ReadLine()!;                        // Taking input

        DateTime date1 = DateTime.ParseExact(input1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(input2, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        CompareDates(date1, date2);                                 // calling the method
    }
}
