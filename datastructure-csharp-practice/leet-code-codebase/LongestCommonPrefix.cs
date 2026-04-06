using System;
using System.Text;

class Solution
{
    public string Common(string s1,string s2)
    {
        StringBuilder sb=new StringBuilder();
        int len=Math.Min(s1.Length,s2.Length);
        for(int i=0;i<len;i++)
        {
            if(s1[i]==s2[i])
            {
                sb.Append(s1[i]);
            }
            else
            {
                break;
            }
        }
        return sb.ToString();
    }

    public string LongestCommonPrefix(string[] strs)
    {
        string result=strs[0];
        for(int i=1;i<strs.Length;i++)
        {
            result=Common(result,strs[i]);
        }
        return result;
    }
}