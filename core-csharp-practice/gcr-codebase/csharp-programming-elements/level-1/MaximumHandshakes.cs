using System;

class MaximumHandshakes
{
    public static void Main(string[] args)
    {
        int numberOfStudents;

        // Read number of students 
        numberOfStudents = Convert.ToInt32(Console.ReadLine());

        // Calculate maximum number of handshakes
        int maxHandshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;

        // Display the result
        Console.WriteLine(
            $"The maximum number of handshakes among {numberOfStudents} students is {maxHandshakes}"
        );
    }
}
