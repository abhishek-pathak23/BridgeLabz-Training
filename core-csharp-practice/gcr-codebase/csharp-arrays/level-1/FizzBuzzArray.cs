using System;

class FizzBuzzArray{
    static void Main()
    {
        Console.Write("Enter a positive number:");
        int n=Convert.ToInt32(Console.ReadLine()); // Taking input

        if(n<1)
        {
            Console.WriteLine("Number must be positive");
            return;
        }

        string[] result=new string[n];

        for(int i=0;i<n;i++)
        {
            if((i+1)%3==0&&(i+1)%5==0)  // Checking all the possible conditions
                result[i]="FizzBuzz";
            else if((i+1)%3==0)
                result[i]="Fizz";
            else if((i+1)%5==0)
                result[i]="Buzz";
            else
                result[i]=(i+1).ToString();
        }

        for(int i=0;i<n;i++)
            Console.WriteLine("Position "+(i+1)+"="+result[i]);
    }
}

