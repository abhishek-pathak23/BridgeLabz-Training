using System;

class GreatestFactorFind
{
    static void Main()
    {
        int number;//take the input
        int greatestFactor=1;

        Console.WriteLine("Enter number:");
        number=Convert.ToInt32(Console.ReadLine());

        for(int i=number-1;i>=1;i--)
        {
            if(number%i==0)//check thr factor
            {
                greatestFactor=i;
                break;
            }
        }

        Console.WriteLine("Greatest factor is "+greatestFactor);
    }
}
