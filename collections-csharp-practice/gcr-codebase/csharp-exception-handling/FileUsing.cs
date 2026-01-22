using System;
using System.IO;

class FileUsing
{
    static void Main()
    {
        Console.Write("File name: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                Console.WriteLine("First Line: " + sr.ReadLine());
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error reading file.");
        }
    }
}
