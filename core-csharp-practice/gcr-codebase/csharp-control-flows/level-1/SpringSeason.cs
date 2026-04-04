using System;

class SpringSeason
{
    static void Main(string[] args)
    {
		//taking the month from user
		Console.Write("Enter the Month number: ");
        int month = Convert.ToInt32(Console.ReadLine());
		//taking the day
		Console.Write("Enter the day: ");
        int day =Convert.ToInt32(Console.ReadLine());
           //checking spring season
        Console.WriteLine( (month == 3 && day >= 20) ||(month == 4) ||(month == 5) ||(month == 6 && day <= 20) ? "Its a Spring Season" : "Not a Spring Season");
    }
}
