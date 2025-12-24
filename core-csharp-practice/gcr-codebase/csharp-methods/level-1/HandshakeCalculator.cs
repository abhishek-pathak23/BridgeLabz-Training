using System;

class HandshakeCalculator
{
    // Method to calculate maximum no of handshakes
    public static int CalculateHandshakes(int numberOfStudents)
    {
        return (numberOfStudents * (numberOfStudents - 1)) / 2;
    }

    static void Main()
    {
        Console.Write("Enter number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        int handshakes = CalculateHandshakes(numberOfStudents);
        Console.WriteLine("Maximum number of handshakes possible: " + handshakes);
    }
}
