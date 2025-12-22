using System;

class AllMultiBelow
{
    static void Main()
    {
        int number;///take the input

        Console.WriteLine("Enter number:");
        number=Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Multiples below 100:");
        for(int i=100;i>=1;i--)
        {
            if(i%number==0) 
            {
                Console.WriteLine(i);
            }
        }
    }
}
