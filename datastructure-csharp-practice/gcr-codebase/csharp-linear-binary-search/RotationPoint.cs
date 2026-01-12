using System;

class RotationPoint
{
    static void Main()
    {
        int[] arr={4,5,6,7,1,2,3};
        int low=0,high=arr.Length-1;

        while(low<high)
        {
            int mid=(low+high)/2;

            if(arr[mid]>arr[high])
                low=mid+1;
            else
                high=mid;
        }

        Console.WriteLine("Rotation index: "+low);
    }
}
