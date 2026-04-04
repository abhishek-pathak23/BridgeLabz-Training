using System;

class VotingEligibilityCheck
{
    static void Main()
    {
	//taking input of age from user
        Console.Write("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());
//checking the user eligibility
        if (age >= 18)
            Console.WriteLine($"The person's age is {age} and can vote.");
        else
            Console.WriteLine($"The person's age is {age} and cannot vote.");
    }
}
