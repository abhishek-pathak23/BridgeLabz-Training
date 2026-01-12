using System;
using System.Text;

class StringReverseDemo
{
    static void Main()
    {
        string input="hello";

        StringBuilder sb=new StringBuilder(input);
        char[] reversed=sb.ToString().ToCharArray();
        Array.Reverse(reversed);

        Console.WriteLine(new string(reversed));
    }
}
