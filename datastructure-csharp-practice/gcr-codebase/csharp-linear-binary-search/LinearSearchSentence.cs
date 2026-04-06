using System;

class LinearSearchSentence
{
    static void Main()
    {
        string[] sentences={
            "I love coding",
            "C sharp is easy",
            "Linear search is simple"
        };

        string word="search";

        for(int i=0;i<sentences.Length;i++)
        {
            if(sentences[i].ToLower().Contains(word.ToLower()))
            {
                Console.WriteLine("Found sentence: "+sentences[i]);
                return;
            }
        }

        Console.WriteLine("Word not found");
    }
}
