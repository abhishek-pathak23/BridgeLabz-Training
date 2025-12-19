
using System;

class FindAveragePCM
{
    public static void Main(string[] args)
    {
        string name = "Sam";

        // Create variables to store marks in each subject
        int mathsMarks = 94;
        int physicsMarks = 95;
        int chemistryMarks = 96;

        // Calculate the total marks obtained in PCM
        int totalMarks = mathsMarks + physicsMarks + chemistryMarks;

        // Calculate the average percentage marks
        double averageMarks = totalMarks / 3.0;

        // Display the result
        Console.WriteLine($"{name}'s average mark in PCM is {averageMarks}");
    }
}
