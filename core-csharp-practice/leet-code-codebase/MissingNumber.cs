public class Solution {
    public int MissingNumber(int[] nums) {
        int n=nums.Length;               //length of the array stored in variable n
        int expectedSum=n*(n+1)/2;       // Calculating the expected sum
        int actualSum=0;                 // actual sum of the elements of array
        for(int i=0;i<nums.Length;i++){
            actualSum+=nums[i];
        }
        return expectedSum-actualSum;    //returning the output

    }
}