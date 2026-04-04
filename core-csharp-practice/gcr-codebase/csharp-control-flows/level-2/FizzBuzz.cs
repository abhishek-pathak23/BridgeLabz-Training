using System;

class FizzBuzz
{
    static void Main()
    {
        int number;

        Console.WriteLine("Enter number:");
        number=Convert.ToInt32(Console.ReadLine()); 

        if(number>0)//check number is positive or not 
        {
            for(int i=1;i<=number;i++) 
            {
                if(i%3==0&&i%5==0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(i%3==0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(i%5==0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
        else
        {
            Console.WriteLine("Enter positive number");
        }
    }
}
