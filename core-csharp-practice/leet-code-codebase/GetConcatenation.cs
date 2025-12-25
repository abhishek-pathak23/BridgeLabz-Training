public class Solution {
    public int[] GetConcatenation(int[] nums) {
        int n = nums.Length;              // storing length of array in n
        int[] result = new int[2 * n];    // creating new array with twice the size of nums array

        for (int i = 0; i < n; i++) {     // looping
            result[i] = nums[i];
            result[i + n] = nums[i];
        }

        return result;                    // returning the result
    }
}
