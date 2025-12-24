using System;

class StudentVoteChecker
{
    // Check if student can vote
    public static bool CanStudentVote(int age)
    {
        if (age < 0) return false;
        return age >= 18;
    }

    static void Main()
    {
        int[] ages = new int[10];

        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write("Enter age: ");
            ages[i] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CanStudentVote(ages[i]) ? "Can Vote" : "Cannot Vote"); //Output
        }
    }
}
