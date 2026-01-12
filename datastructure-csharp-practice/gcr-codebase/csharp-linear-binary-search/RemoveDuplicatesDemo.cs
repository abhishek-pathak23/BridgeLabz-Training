using System;
using System.Text;
using System.Collections.Generic;

class RemoveDuplicatesDemo
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input=Console.ReadLine();

        HashSet<char> visited=new HashSet<char>();
        StringBuilder result=new StringBuilder();

        foreach(char ch in input)
        {
            if(!visited.Contains(ch))
            {
                visited.Add(ch);
                result.Append(ch);
            }
        }

        Console.WriteLine("Result after removing duplicates: "+result.ToString());
    }
}
