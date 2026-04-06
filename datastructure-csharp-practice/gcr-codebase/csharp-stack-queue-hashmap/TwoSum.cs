using System;
using System.Collections.Generic;

class TwoSum
{
    static void FindIndices(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];

            if (map.ContainsKey(diff))
            {
                Console.WriteLine(map[diff] + ", " + i);
                return;
            }

            map[nums[i]] = i;
        }
    }

    static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        FindIndices(nums, 9);
    }
}
