using System;

class LeapYearChecker
{
    // Check if year is leap year or not
    public static bool IsLeapYear(int year)
    {
        if (year < 1582) return false;
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    static void Main()
    {
        Console.Write("Enter the year: ");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(IsLeapYear(year) ? "Leap Year" : "Not a Leap Year");
    }
}
