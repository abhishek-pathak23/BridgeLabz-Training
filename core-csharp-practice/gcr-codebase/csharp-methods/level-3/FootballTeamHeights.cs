using System;

class FootballTeamHeights
{
    // Generate random heights for players
    public static int[] GetHeights(int players)
    {
        Random rand = new Random();
        int[] heights = new int[players];
        for (int i = 0; i < players; i++)
            heights[i] = rand.Next(150, 251); // 150-250 cm
        return heights;
    }

    // Find shortest height
    public static int FindShortest(int[] array)
    {
        int min = int.MaxValue;
        foreach (int h in array) if (h < min) min = h;
        return min;
    }

    // Find tallest height
    public static int FindTallest(int[] array)
    {
        int max = int.MinValue;
        foreach (int h in array) if (h > max) max = h;
        return max;
    }

    // Calculate mean height
    public static double FindMean(int[] array)
    {
        int sum = 0;
        foreach (int h in array) sum += h;
        return (double)sum / array.Length;
    }

    static void Main()
    {
        int[] heights = GetHeights(11); // Get 11 random player heights

        Console.WriteLine("Player Heights:");
        foreach (int h in heights) Console.Write(h + " ");
        Console.WriteLine();

        // Display shortest, tallest, and mean
        Console.WriteLine("Shortest: " + FindShortest(heights));
        Console.WriteLine("Tallest: " + FindTallest(heights));
        Console.WriteLine("Mean: " + Math.Round(FindMean(heights), 2));
    }
}
