using System;
using System.Text;
using System.Diagnostics;

class StringBuilderPerformanceDemo
{
    static void Main()
    {
        int iterations=100000;

        // Measure performance of string concatenation
        Stopwatch watch=new Stopwatch();
        watch.Start();

        string normalString="";
        for(int i=0;i<iterations;i++)
        {
            normalString+=i;
        }

        watch.Stop();
        Console.WriteLine("String time: "+watch.ElapsedMilliseconds+" ms");

        // Measure performance of StringBuilder
        watch.Reset();
        watch.Start();

        StringBuilder sb=new StringBuilder();
        for(int i=0;i<iterations;i++)
        {
            sb.Append(i);
        }

        watch.Stop();
        Console.WriteLine("StringBuilder time: "+watch.ElapsedMilliseconds+" ms");
    }
}
