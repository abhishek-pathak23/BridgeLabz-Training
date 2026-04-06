using System;
using System.IO;

class FileLineReader
{
    static void Main()
    {
         string filePath="C:\\C sharp\\StringStringBuilder\\sample.txt";

        try
        {
            using(StreamReader reader=new StreamReader(filePath))
            {
                string line;
                while((line=reader.ReadLine())!=null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: "+e.Message);
        }
    }
}
