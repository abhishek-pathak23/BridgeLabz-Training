using System;

class FriendsInfo
{
    static void Main()
    {
        string[] friendNames = { "Amar", "Akbar", "Anthony" };
        int[] friendAges = new int[3];
        double[] friendHeights = new double[3];

        // Input age and height
        for (int i = 0; i < friendNames.Length; i++)
        {
            // Age input with validation
            while (true)
            {
                Console.WriteLine($"Enter the age of {friendNames[i]}:");
                string? inputAge = Console.ReadLine();
                if (int.TryParse(inputAge, out int age) && age >= 0)
                {
                    friendAges[i] = age;
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid non-negative integer.");
            }

            // Height input with validation
            while (true)
            {
                Console.WriteLine($"Enter the height (in cm) of {friendNames[i]}:");
                string? inputHeight = Console.ReadLine();
                if (double.TryParse(inputHeight, out double height) && height >= 0)
                {
                    friendHeights[i] = height;
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid non-negative number.");
            }
        }

        // Find youngest friend
        int indexYoungest = 0;
        for (int i = 1; i < friendNames.Length; i++)
        {
            if (friendAges[i] < friendAges[indexYoungest])
                indexYoungest = i;
        }

        // Find tallest friend
        int indexTallest = 0;
        for (int i = 1; i < friendNames.Length; i++)
        {
            if (friendHeights[i] > friendHeights[indexTallest])
                indexTallest = i;
        }

        // Display results
        Console.WriteLine($"\nThe youngest friend is {friendNames[indexYoungest]} ({friendAges[indexYoungest]} years old).");
        Console.WriteLine($"The tallest friend is {friendNames[indexTallest]} ({friendHeights[indexTallest]} cm tall).");
    }
}
