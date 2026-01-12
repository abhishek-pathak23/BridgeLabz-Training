using System;

class MatrixBinarySearch
{
    static void Main()
    {
        int[,] matrix={
            {1,3,5},
            {7,9,11},
            {13,15,17}
        };

        int target=9;
        int rows=3,cols=3;
        int low=0,high=rows*cols-1;

        while(low<=high)
        {
            int mid=(low+high)/2;
            int r=mid/cols;
            int c=mid%cols;

            if(matrix[r,c]==target)
            {
                Console.WriteLine("Found");
                return;
            }
            else if(matrix[r,c]<target)
                low=mid+1;
            else
                high=mid-1;
        }

        Console.WriteLine("Not Found");
    }
}
