using System;
using System.Collections.Generic;

class SlidingWindowMax
{
    static void FindMax(int[] arr, int k)
    {
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            // Remove elements outside the window
            if (deque.Count > 0 && deque.First.Value <= i - k)
                deque.RemoveFirst();

            // Remove smaller elements
            while (deque.Count > 0 && arr[deque.Last.Value] < arr[i])
                deque.RemoveLast();

            deque.AddLast(i);

            // Print max when window is ready
            if (i >= k - 1)
                Console.Write(arr[deque.First.Value] + " ");
        }
    }

    static void Main()
    {
        int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
        FindMax(arr, 3);
    }
}
