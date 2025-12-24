using System;

class ArraysOddEven
{
    static void Main()
    {
        Console.Write("Enter array size ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        int[] even = new int[n];
        int[] odd = new int[n];

        int e = 0, o = 0;

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());

            if (arr[i] % 2 == 0)
                even[e++] = arr[i];
            else
                odd[o++] = arr[i];
        }

        Console.WriteLine("Even elements are:");
        for (int i = 0; i < e; i++)
            Console.Write(even[i] + " ");

        Console.WriteLine("\nOdd elements:");
        for (int i = 0; i < o; i++)
            Console.Write(odd[i] + " ");
    }
}
