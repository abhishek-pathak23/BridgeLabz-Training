using System;
using System.IO;

class ConsoleToFileDemo
{
    static void Main()
    {
        string filePath="C:\\C sharp\\StringStringBuilder\\output.txt";
        try
        {
            using(StreamReader inputReader=new StreamReader(Console.OpenStandardInput()))
            using(StreamWriter writer=new StreamWriter(filePath))
            {
                Console.WriteLine("Enter text (type exit to stop):");

                string line;
                while((line=inputReader.ReadLine())!="exit")
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Data saved to file successfully.");
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: "+e.Message);
        }
    }
}
