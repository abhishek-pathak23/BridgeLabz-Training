using System;

class DateFormattingProg
{
    // Method to prints date in diff formats
    static void DisplayFormattedDates(DateTime date)
    {
        Console.WriteLine("Format (dd/MM/yyyy): " + date.ToString("dd/MM/yyyy"));
        Console.WriteLine("Format (yyyy-MM-dd): " + date.ToString("yyyy-MM-dd"));
        Console.WriteLine("Format (EEE, MMM dd, yyyy): " + date.ToString("ddd, MMM dd, yyyy"));
    }

    static void Main()
    {
        DateTime currentDate = DateTime.Now;
        DisplayFormattedDates(currentDate);           //  calling the method
    }
}
