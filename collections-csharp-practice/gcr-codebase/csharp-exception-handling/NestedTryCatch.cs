using System;

class NestedTryCatch
{
    static void Main()
    {
        Console.Write("Array size: ");
        int size = int.Parse(Console.ReadLine());
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write($"Element {i}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Index to divide: ");
        int index = int.Parse(Console.ReadLine());
        Console.Write("Divisor: ");
        int divisor = int.Parse(Console.ReadLine());

        try
        {
            int val = arr[index];
            try
            {
                Console.WriteLine("Result: " + (val / divisor));
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid array index!");
        }
    }
}
