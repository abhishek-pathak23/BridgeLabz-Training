using System;

class PeakElement
{
    static void Main()
    {
        int[] arr={1,3,20,4,1};
        int low=0,high=arr.Length-1;

        while(low<high)
        {
            int mid=(low+high)/2;

            if(arr[mid]<arr[mid+1])
                low=mid+1;
            else
                high=mid;
        }

        Console.WriteLine("Peak element: "+arr[low]);
    }
}
