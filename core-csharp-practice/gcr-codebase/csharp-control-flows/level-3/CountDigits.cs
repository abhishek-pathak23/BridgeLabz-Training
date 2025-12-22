using System;

class CountDigits
{
    static void Main()
    {
        int number;//take the input 
        int count=0;

        Console.WriteLine("Enter number:");
        number=Convert.ToInt32(Console.ReadLine());

        //count the digts
        while(number!=0)
        {
            number=number/10; //remove thr digit
            count++;
        }

        Console.WriteLine("Number of digits is "+count);
    }
}
