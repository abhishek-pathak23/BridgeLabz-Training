using System;

class NumCheck
{
    static void Main()
    {
	//taking the number as input
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
//checking the number 
        if (num > 0)
            Console.WriteLine("positive");
        else if (num < 0)
            Console.WriteLine("negative");
        else
            Console.WriteLine("zero");
    }
}
