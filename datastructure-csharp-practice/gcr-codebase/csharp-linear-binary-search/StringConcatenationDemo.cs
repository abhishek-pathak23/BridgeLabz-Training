using System;
using System.Text;

class StringConcatenationDemo
{
    static void Main()
    {
        Console.Write("Enter number of strings: ");
        int count=int.Parse(Console.ReadLine());

        // StringBuilder for efficient string concatenation
        StringBuilder result=new StringBuilder();

        for(int i=1;i<=count;i++)
        {
            Console.Write("Enter string "+i+": ");
            string input=Console.ReadLine();

            // Append each string to StringBuilder
            result.Append(input);
        }

        // Convert StringBuilder to string once
        Console.WriteLine("Final concatenated string: "+result.ToString());
    }
}
