using System;

class CounterNum
{
    static void Main()
    {
		//enter the number
        Console.Write("Enter countdown start number: ");
        int counter = Convert.ToInt32(Console.ReadLine());
//checking while the number is greater than 1
        while (counter >= 1)
        {
            Console.WriteLine(counter);
            counter--;
        }
    }
}
