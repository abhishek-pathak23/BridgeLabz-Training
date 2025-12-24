using System;

class FriendsAnalyzerProg
{
    // Find youngest
    public static int FindYoungest(int[] ages)
    {
        int min = ages[0];
        foreach (int age in ages) min = Math.Min(min, age);
        return min;
    }

    // Find tallest
    public static int FindTallest(int[] heights)
    {
        int max = heights[0];
        foreach (int h in heights) max = Math.Max(max, h);
        return max;
    }

    static void Main()
    {
        int[] ages = new int[3];
        int[] heights = new int[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter age: ");
            ages[i] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height: ");
            heights[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Youngest Age: " + FindYoungest(ages));
        Console.WriteLine("Tallest Height: " + FindTallest(heights));
    }
}
