using System;

class SearchChallenge
{
    static void Main()
    {
        int[] arr={3,4,-1,1};
        int target=4;

        int missing=FindFirstMissingPositive(arr);
        Console.WriteLine("First missing positive: "+missing);

        Array.Sort(arr);
        int index=BinarySearch(arr,target);

        Console.WriteLine("Target index: "+index);
    }

    // Linear Search to find first missing positive number
    static int FindFirstMissingPositive(int[] arr)
    {
        bool[] seen=new bool[arr.Length+1];

        for(int i=0;i<arr.Length;i++)
        {
            if(arr[i]>0 && arr[i]<=arr.Length)
            {
                seen[arr[i]]=true;
            }
        }

        for(int i=1;i<=arr.Length;i++)
        {
            if(!seen[i])
                return i;
        }

        return arr.Length+1;
    }

    // Binary Search to find target index
    static int BinarySearch(int[] arr,int target)
    {
        int low=0,high=arr.Length-1;

        while(low<=high)
        {
            int mid=(low+high)/2;

            if(arr[mid]==target)
                return mid;
            else if(arr[mid]<target)
                low=mid+1;
            else
                high=mid-1;
        }

        return -1;
    }
}
