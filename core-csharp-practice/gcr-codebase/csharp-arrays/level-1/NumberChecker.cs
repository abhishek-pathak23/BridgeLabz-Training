using System;

class NumberChecker{
    static void Main(){
        int[] nums=new int[5]; //initializing the array
        for(int i=0;i<5;i++){
            Console.Write("Enter number "+(i+1)+": ");
            nums[i]=Convert.ToInt32(Console.ReadLine());
        }

        for(int i=0;i<5;i++){     // Looping and checking the conditions
            if(nums[i]>0)
            {
                Console.Write(nums[i]+" is Positive ");
                if(nums[i]%2==0)
                {
                    Console.WriteLine("Even");
                }
                else
                {
                    Console.WriteLine("Odd");
                }
            }
            else if(nums[i]<0)
            {
                Console.WriteLine(nums[i]+" is Negative");
            }
            else
            {
                Console.WriteLine(nums[i]+" is Zero");
            }
        }

        if(nums[0]==nums[4])               // Looping and checking the conditions
        {
            Console.WriteLine("First and last elements Equal");
        }
        else if(nums[0]>nums[4])
        {
            Console.WriteLine("First element Greater than last");
        }
        else
        {
            Console.WriteLine("First element Less than last");
        }
    }
}

