using System;

class CountingSort
{
    static void Main()
    {
        int[] ages = { 12, 15, 11, 14, 13, 12, 16 };
        int minAge = 10;
        int maxAge = 18;

        int[] count = new int[maxAge - minAge + 1];

        // Count frequency of each age
        foreach (int age in ages)
        {
            count[age - minAge]++;
        }

        // Rebuild sorted array
        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                ages[index++] = i + minAge;
                count[i]--;
            }
        }

        Console.WriteLine("Sorted Student Ages:");
        foreach (int a in ages)
        {
            Console.Write(a + " ");
        }
    }
}
