using System;
class VotingEligibilityCheck
{
    static void Main()
    {
        int[] age=new int[10]; //array for storing the age of 10 Students
        for(int i = 0; i < age.Length; i++)
        {
            Console.WriteLine("Enter the age of student " +(i+1)+ ":");
            age[i]=Convert.ToInt32(Console.ReadLine());// taking the input from the user
        }

        for(int i=0;i< age.Length; i++)        // Looping and checking the all possible conditions
        {
            if (age[i] < 0)
            {
                Console.WriteLine("Student" +(i+1)+ ":Invalid age");
            }
            else if (age[i] < 18)
            {
                Console.WriteLine("Student" +(i+1)+ ":Not eligible for voting ");
            }
            else
            {
                Console.WriteLine("Student" +(i+1)+ ":Eligible for voting ");
            }
        }





    }
}