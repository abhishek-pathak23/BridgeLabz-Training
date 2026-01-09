using System;

class MergeSort
{
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            // Divide array into two halves
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            // Merge the sorted halves
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;

        // Compare and merge
        while (i <= mid && j <= right)
        {
            if (arr[i] < arr[j])
                temp[k++] = arr[i++];
            else
                temp[k++] = arr[j++];
        }

        // Copy remaining elements
        while (i <= mid)
            temp[k++] = arr[i++];

        while (j <= right)
            temp[k++] = arr[j++];

        // Copy back to original array
        for (int m = 0; m < temp.Length; m++)
            arr[left + m] = temp[m];
    }

    static void Main()
    {
        int[] prices = { 450, 120, 300, 200, 150 };

        MergeSort(prices, 0, prices.Length - 1);

        Console.WriteLine("Sorted Book Prices:");
        foreach (int p in prices)
        {
            Console.Write(p + " ");
        }
    }
}
