using System;
using System.IO;

class WordCountInFile
{
    static void Main()
    {
        string filePath="C:\\C sharp\\StringStringBuilder\\sample.txt";

        Console.Write("Enter word to search: ");
        string searchWord=Console.ReadLine();

        int count=0;

        try
        {
            using(StreamReader reader=new StreamReader(filePath))
            {
                string line;
                while((line=reader.ReadLine())!=null)
                {
                    string[] words=line.Split(' ','.',',','!','?');

                    foreach(string word in words)
                    {
                        if(word.Equals(searchWord,StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine("Word count: "+count);
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: "+e.Message);
        }
    }
}
