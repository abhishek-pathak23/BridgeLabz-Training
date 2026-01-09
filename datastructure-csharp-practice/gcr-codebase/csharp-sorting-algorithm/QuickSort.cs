using System;

class QuickSort
{
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            // Sort left and right parts
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                // Swap
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        // Place pivot at correct position
        int t = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = t;

        return i + 1;
    }

    static void Main()
    {
        int[] prices = { 999, 299, 499, 199, 699 };

        QuickSort(prices, 0, prices.Length - 1);

        Console.WriteLine("Sorted Product Prices:");
        foreach (int p in prices)
        {
            Console.Write(p + " ");
        }
    }
}
