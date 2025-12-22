using System;

class LeapYearMultiple
{
    static void Main(string[] args)
    {
        // Read year input from user
        Console.WriteLine("Enter a year:");
        int year = Convert.ToInt32(Console.ReadLine());

        // Check if year is valid as per Gregorian calendar
        if (year < 1582)
        {
            Console.WriteLine("Leap Year calculation is valid only for year >= 1582");
        }
        else
        {
            // Check leap year conditions using multiple if-else
            if (year % 400 == 0)
            {
                Console.WriteLine("The Year is a Leap Year:");
            }
            else if (year % 100 == 0)
            {
                Console.WriteLine("The Year is not a Leap Year:");
            }
            else if (year % 4 == 0)
            {
                Console.WriteLine("The Year is a Leap Year:");
            }
            else
            {
                Console.WriteLine("The Year is not a Leap Year:");
            }
        }
    }
}
