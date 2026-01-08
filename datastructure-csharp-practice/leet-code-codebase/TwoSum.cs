public class Solution{
    public int[] TwoSum(int[] nums,int target){
        Dictionary<int,int> map=new Dictionary<int,int>();
        for(int i=0;i<nums.Length;i++){
            int remainingValue=target-nums[i];
            if(map.ContainsKey(remainingValue)){
                return new int[]{map[remainingValue],i};
            }
            if(!map.ContainsKey(nums[i])){
                map.Add(nums[i],i);
            }
        }
        return new int[]{-1,-1};
    }
}