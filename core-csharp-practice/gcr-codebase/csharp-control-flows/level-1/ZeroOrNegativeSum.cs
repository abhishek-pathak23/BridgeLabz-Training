using System;

class ZeroOrNegativeSum
{
    static void Main(String[] args)
    {
        double total = 0.0;
//true until user enter 0 or negative number to stop the loop
        while (true)
        {
            Console.Write("Enter a number (<=0 to stop): ");
            double num=Convert.ToDouble(Console.ReadLine());
//if num is less than or equal to 0 then break out of loop
            if (num <= 0){
			break;}
			
            total += num;
        }
        Console.WriteLine($"Total is {total}");
    }
}
