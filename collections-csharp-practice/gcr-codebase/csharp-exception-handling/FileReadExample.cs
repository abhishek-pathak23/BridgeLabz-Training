using System;
using System.IO;

class FileReadExample
{
    static void Main()
    {
        try
        {
            string content = File.ReadAllText("data.txt");
            Console.WriteLine(content);
        }
        catch (IOException)
        {
            Console.WriteLine("File not found");
        }
    }
}
