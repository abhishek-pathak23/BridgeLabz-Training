using System;

class InsertionSort
{
    static void Main()
    {
        int[] empIds = { 105, 101, 108, 102, 104 };

        // Insertion Sort logic
        for (int i = 1; i < empIds.Length; i++)
        {
            int key = empIds[i];
            int j = i - 1;

            // Move elements greater than key to one position ahead
            while (j >= 0 && empIds[j] > key)
            {
                empIds[j + 1] = empIds[j];
                j--;
            }

            // Insert key at correct position
            empIds[j + 1] = key;
        }

        // Display sorted employee IDs
        Console.WriteLine("Sorted Employee IDs:");
        foreach (int id in empIds)
        {
            Console.Write(id + " ");
        }
    }
}
