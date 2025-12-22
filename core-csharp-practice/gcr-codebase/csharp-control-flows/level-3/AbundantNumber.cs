using System;

class AbundantNumber
{
    static void Main()
    {
        int number;//taking input
        int sum=0;

        Console.WriteLine("Enter number:");
        number=Convert.ToInt32(Console.ReadLine());

        //finding the divisors
        for(int i=1;i<number;i++)
        {
            if(number%i==0)
                sum=sum+i;
        }

 
        if(sum>number)
            Console.WriteLine("Abundant Number");
        else
            Console.WriteLine("Not an Abundant Number");
    }
}
