using System;

class LinearSearchNegative
{
    static void Main()
    {
        int[] arr={5,10,3,-4,8};

        for(int i=0;i<arr.Length;i++)
        {
            if(arr[i]<0)
            {
                Console.WriteLine("First negative number: "+arr[i]);
                return;
            }
        }

        Console.WriteLine("No negative number found");
    }
}
