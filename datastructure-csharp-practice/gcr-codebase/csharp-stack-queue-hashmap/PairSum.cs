using System;
using System.Collections.Generic;

class PairSum
{
    static void FindPair(int[] arr, int target)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in arr)
        {
            if (set.Contains(target - num))
            {
                Console.WriteLine("Pair Found");
                return;
            }
            set.Add(num);
        }

        Console.WriteLine("Pair Not Found");
    }

    static void Main()
    {
        int[] arr = { 8, 7, 2, 5, 3, 1 };
        FindPair(arr, 10);
    }
}
