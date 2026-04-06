using System;

class BubbleSort
{
    static void Main()
    {
        int[] marks = { 45, 78, 62, 90, 55 };

        // Bubble Sort logic
        for (int i = 0; i < marks.Length - 1; i++)
        {
            for (int j = 0; j < marks.Length - i - 1; j++)
            {
                // Compare adjacent elements
                if (marks[j] > marks[j + 1])
                {
                    // Swap if they are in wrong order
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                }
            }
        }

        // Display sorted marks
        Console.WriteLine("Sorted Student Marks:");
        foreach (int m in marks)
        {
            Console.Write(m + " ");
        }
    }
}
