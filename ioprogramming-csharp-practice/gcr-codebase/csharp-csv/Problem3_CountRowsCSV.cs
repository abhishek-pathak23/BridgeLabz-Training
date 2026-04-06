using System;
using System.IO;

class Problem3_CountRowsCSV
{
    static void Main()
    {
        string filePath = "employees.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        var lines = File.ReadAllLines(filePath);

        int count = lines.Length - 1; // exclude header
        Console.WriteLine("Total records (excluding header): " + count);
    }
}