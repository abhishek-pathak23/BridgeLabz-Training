using System;
using System.IO;
using System.Collections.Generic;

class Problem2_WriteCSV
{
    static void Main()
    {
        string filePath = "employees.csv";

        var employees = new List<string>
        {
            "ID,Name,Department,Salary",
            "101,John,IT,50000",
            "102,Emma,HR,45000",
            "103,Liam,IT,55000",
            "104,Olivia,Finance,60000",
            "105,Noah,Marketing,40000"
        };

        File.WriteAllLines(filePath, employees);

        Console.WriteLine("CSV file created with 5 employee records.");
    }
}