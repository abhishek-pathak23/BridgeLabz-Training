using System;

class DayOfWeeks5
{
    static void Main()
    {
        int m,d,y;

        Console.WriteLine("Enter month:");
        m=Convert.ToInt32(Console.ReadLine());//rake the inpot 
        Console.WriteLine("Enter day:");
        d=Convert.ToInt32(Console.ReadLine());//talh the ionpot 
        Console.WriteLine("Enter year:");
        y=Convert.ToInt32(Console.ReadLine());//talk the inpot 

        int y0=y-(14-m)/12;
        int x=y0+y0/4-y0/100+y0/400;
        int m0=m+12*((14-m)/12)-2;
        int d0=(d+x+(31*m0)/12)%7;

        Console.WriteLine("Day is "+d0);
    }
}