using System;

class FactorsOfNum
{
    static void Main()
    {
        int number;//take the input

        Console.WriteLine("Enter number:");
        number=Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Factors are:");

        //find the factors
        for(int i=1;i<number;i++)
        {
            if(number%i==0) //check the divisibility
            {
                Console.WriteLine(i);
            }
        }
    }
}
