using System;
using System.IO;

class Problem11_ReadLargeCSV
{
    static void Main()
    {
        string filePath = "large.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        int chunkSize = 100;
        int count = 0;

        using (var reader = new StreamReader(filePath))
        {
            string header = reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                count++;
                // Process line if needed
                if (count % chunkSize == 0)
                    Console.WriteLine($"{count} records processed...");
            }
        }

        Console.WriteLine("Total records processed: " + count);
    }
}