using System;

class ArrayOperations
{
    static void Main()
    {
        int[] arr = null; // Or test with: int[] arr = {1,2,3};
        Console.Write("Enter index: ");
        int index = int.Parse(Console.ReadLine());

        try
        {
            Console.WriteLine("Value at index " + index + ": " + arr[index]);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid index!");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Array is not initialized!");
        }
    }
}
