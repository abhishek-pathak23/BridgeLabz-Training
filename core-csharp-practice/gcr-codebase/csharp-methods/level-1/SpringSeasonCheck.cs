using System;

class SpringSeasonCheck
{
    static bool IsSpring(int month,int day)//method to check spring season
    {
        if((month==3 && day>=20)||
           (month>3 && month<6)||
           (month==6 && day<=20))
            return true;
        return false;
    }

    static void Main()
    {
        Console.Write("Enter month: ");
        int month=Convert.ToInt32(Console.ReadLine());//Taking the input from user

        Console.Write("Enter day: ");
        int day=Convert.ToInt32(Console.ReadLine());//Taking the input from user
        //checking the season
        if(IsSpring(month,day))
            Console.WriteLine("Its a Spring Season");
        else
            Console.WriteLine("Not a Spring Season");
    }
}