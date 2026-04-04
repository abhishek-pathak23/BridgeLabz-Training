using System;

class ArrayIndexOutOfRangeProg
{
    static void Main()
    {
        // Take array size from user
        Console.Write("Enter the size of the array: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[size];

        // Take array elements
        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Take index to access
        Console.Write("Enter the index you want to access: ");
        int index = Convert.ToInt32(Console.ReadLine());

        try
        {
            Console.WriteLine($"Element at index {index}: {arr[index]}");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("Caught the Array IndexOutOfRangeException: " + e.Message);
        }
    }
}
