using System;
using System.IO;

class FileReadingComparison
{
    static void ReadUsingStreamReader(string path)
    {
        // StreamReader reads character by character
        StreamReader reader = new StreamReader(path);
        string line;
        
            while ((line=reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                // Reading each line (slower for large files)
            }
        
        Console.WriteLine("File read using StreamReader.");
    }

    static void ReadUsingFileStream(string path)
    {
        // FileStream reads raw bytes
        FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read);
        
            int i;
            while ((i=fs.ReadByte()) != -1)
            {
                Console.Write((char)i);
                // Reading chunks of bytes (faster)
            }
        
        Console.WriteLine("File read using FileStream.");
    }

    static void Main()
    {
        string filePath = "C:\\C sharp\\csharp-algorithms\\test.txt";

        ReadUsingStreamReader(filePath);
        ReadUsingFileStream(filePath);
    }
}
