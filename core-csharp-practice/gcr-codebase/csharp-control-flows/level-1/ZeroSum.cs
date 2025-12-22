using System;

class ZeroSum
{
    static void Main(String[] args)
    {
        double total = 0.0;
//true until user enter 0 to stop
        while (true)
        {
            Console.Write("Enter a number (0 to stop): ");
            double num=Convert.ToDouble(Console.ReadLine());
//if num is 0 then break out of loop
            if (num == 0){
			break;}
			
            total += num;
        }
        Console.WriteLine($"Total is {total}");
    }
}
