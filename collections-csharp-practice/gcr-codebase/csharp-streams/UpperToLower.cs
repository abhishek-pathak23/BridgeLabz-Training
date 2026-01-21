using System;
using System.IO;
using System.Text;

class UpperToLower
{
    static void Main()
    {
        string sourcePath = "C:\\C sharp\\BridgeLabzDup\\BridgeLabzDup\\collections-csharp-practice\\gcr-codebase\\csharp-streams\\source.txt";
        string destPath = @"C:\C sharp\BridgeLabzDup\BridgeLabzDup\collections-csharp-practice\gcr-codebase\csharp-streams\output.txt";

        try
        {
            // Check if source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found: " + sourcePath);
                return;
            }

            using (BufferedStream bs = new BufferedStream(File.OpenRead(sourcePath)))
            using (StreamReader reader = new StreamReader(bs, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(destPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line.ToLower());
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Permission denied while accessing the file.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Destination directory not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("File error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}
