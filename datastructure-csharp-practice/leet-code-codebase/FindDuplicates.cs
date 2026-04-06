public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        Dictionary<int,int> dt=new Dictionary<int,int>();
        for(int i=0;i<nums.Length;i++){
            if(dt.ContainsKey(nums[i])){
                dt[nums[i]]++;
            }
            else{
                dt[nums[i]]=1;
            }
            
        }
         List<int> ll=new List<int>();
        
        foreach(int i in dt.Keys){
            if(dt[i]>=2){
                ll.Add(i);
            }
        }
       
       
        return ll;
    }
}