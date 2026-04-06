using System;

class SearchComparison
{
    // Linear Search Method
    // Checks each element one by one
    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                return i; // Target found
            }
        }
        return -1; // Target not found
    }

    // Binary Search Method
    // Works only on sorted arrays
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid; // Target found

            if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1; // Target not found
    }

    static void Main()
    {
        // Sample dataset
        int[] data = { 5, 10, 15, 20, 25, 30, 35 };
        int target = 25;

        // Linear Search
        int linearResult = LinearSearch(data, target);
        Console.WriteLine("Linear Search Result Index: " + linearResult);

        // Binary Search (array already sorted)
        int binaryResult = BinarySearch(data, target);
        Console.WriteLine("Binary Search Result Index: " + binaryResult);
    }
}
