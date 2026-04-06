using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
    static int FindLongestSequence(int[] nums)
    {
        // If array is empty, return 0
        if (nums.Length == 0)
            return 0;

        // HashSet to store all elements
        HashSet<int> set = new HashSet<int>();

        // Add all numbers to HashSet
        foreach (int num in nums)
        {
            set.Add(num);
        }

        int longestLength = 0;

        // Check each number in the array
        foreach (int num in nums)
        {
            // Check if this number is the start of a sequence
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int currentLength = 1;

                // Count consecutive numbers
                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentLength++;
                }

                // Update longest sequence length
                longestLength = Math.Max(longestLength, currentLength);
            }
        }

        return longestLength;
    }

    static void Main()
    {
        int[] nums = { 100, 4, 200, 1, 3, 2 };

        int result = FindLongestSequence(nums);

        Console.WriteLine("Longest Consecutive Sequence Length: " + result);
    }
}