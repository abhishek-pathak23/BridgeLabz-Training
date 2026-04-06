using System;

class HeapSort
{
    static void HeapSort(int[] arr)
    {
        int n = arr.Length;

        // Build Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // Extract elements one by one
        for (int i = n - 1; i > 0; i--)
        {
            // Move root to end
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            Heapify(arr, n, largest);
        }
    }

    static void Main()
    {
        int[] salaries = { 50000, 30000, 70000, 40000 };

        HeapSort(salaries);

        Console.WriteLine("Sorted Salary Demands:");
        foreach (int s in salaries)
        {
            Console.Write(s + " ");
        }
    }
}
