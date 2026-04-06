using System;

class SelectionSort
{
    static void Main()
    {
        int[] scores = { 72, 85, 60, 90, 78 };

        for (int i = 0; i < scores.Length - 1; i++)
        {
            int minIndex = i;

            // Find minimum element
            for (int j = i + 1; j < scores.Length; j++)
            {
                if (scores[j] < scores[minIndex])
                    minIndex = j;
            }

            // Swap
            int temp = scores[i];
            scores[i] = scores[minIndex];
            scores[minIndex] = temp;
        }

        Console.WriteLine("Sorted Exam Scores:");
        foreach (int s in scores)
        {
            Console.Write(s + " ");
        }
    }
}
