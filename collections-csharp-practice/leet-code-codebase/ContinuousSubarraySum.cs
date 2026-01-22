class Solution {
    public bool CheckSubarraySum(int[] nums,int k) {
        Dictionary<int,int> map=new Dictionary<int,int>();
        int prefixsum=0;
        for(int i=0;i<nums.Length;i++){
            prefixsum+=nums[i];
            int rem=prefixsum%k;
            if(rem==0 && i>=1){
                return true;
            }
            if(map.ContainsKey(rem)){
                int idx=map[rem];
                if(i-idx>=2){
                    return true;
                }
            }
            else{
                map.Add(rem,i);
            }
        }
        return false;
    }
}