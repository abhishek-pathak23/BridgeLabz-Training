using System;

class FirstLastOccurrence
{
    static void Main()
    {
        int[] arr={1,2,2,2,3,4};
        int target=2;

        int first=-1,last=-1;
        int low=0,high=arr.Length-1;

        // first occurrence
        while(low<=high)
        {
            int mid=(low+high)/2;

            if(arr[mid]==target)
            {
                first=mid;
                high=mid-1;
            }
            else if(arr[mid]<target)
                low=mid+1;
            else
                high=mid-1;
        }

        low=0;high=arr.Length-1;

        // last occurrence
        while(low<=high)
        {
            int mid=(low+high)/2;

            if(arr[mid]==target)
            {
                last=mid;
                low=mid+1;
            }
            else if(arr[mid]<target)
                low=mid+1;
            else
                high=mid-1;
        }

        Console.WriteLine("First: "+first+" Last: "+last);
    }
}
