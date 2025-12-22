using System;

class FizzBuzzWhileLoop
{
    static void Main()
    {
        int number,i=1;//take the input

        Console.WriteLine("Enter number:");
        number=Convert.ToInt32(Console.ReadLine());

        if(number>0)//check the positive number
        {
            while(i<=number)
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
                i++;
            }
        }
        else
        {
            Console.WriteLine("Enter positive number");
        }
    }
}
