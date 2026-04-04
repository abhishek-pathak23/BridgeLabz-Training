public class Solution {
    public int[] TwoSum(int[] nums, int target) {

        for (int i = 0; i < nums.Length; i++) {             //looping through the array
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] + nums[j] == target) {          //checking if the condition is met
                    return new int[] { i, j };
                }
            }
        }

        return new int[0];                                  //returning the value
    }
}
