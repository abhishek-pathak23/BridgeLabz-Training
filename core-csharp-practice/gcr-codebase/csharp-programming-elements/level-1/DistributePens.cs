
using System;

class DistributePens
{
    public static void Main(string[] args)
    {

        int totalPens = 14;

        int totalStudents = 3;

        int pensPerStudent = totalPens / totalStudents;

        // Calculate the remaining pens using modulus operator
        int remainingPens = totalPens % totalStudents;

        Console.WriteLine(
            $"The Pen Per Student is {pensPerStudent} and the remaining pen not distributed is {remainingPens}"
        );
    }
}
