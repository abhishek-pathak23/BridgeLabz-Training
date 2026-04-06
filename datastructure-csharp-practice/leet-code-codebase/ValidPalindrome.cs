public class Solution {
    public bool IsPalindrome(string s) {
        string str=s.ToLower();
        StringBuilder ans=new StringBuilder(); 
        for(int i=0;i<str.Length;i++){
            if(char.IsLetterOrDigit(str[i])){
                ans.Append(str[i]);
            }
        }
       string original=ans.ToString();
        string reverse="";
       for(int i=original.Length-1;i>=0;i--){
        reverse+=original[i];
       }
       if(reverse==original){
        return true;
       }
       return false;
    }
}