using System;
using System.Diagnostics;
using System.IO;

class BufferedVsNormal
{
    static void CopyFile(string src, string dest, bool buffered)
    {
        Stopwatch sw = Stopwatch.StartNew();

        using (FileStream fsRead = new FileStream(src, FileMode.Open))
        using (FileStream fsWrite = new FileStream(dest, FileMode.Create))
        {
            Stream readStream = buffered ? new BufferedStream(fsRead, 4096) : fsRead;
            Stream writeStream = buffered ? new BufferedStream(fsWrite, 4096) : fsWrite;

            byte[] buffer = new byte[4096];
            int bytes;

            while ((bytes = readStream.Read(buffer, 0, buffer.Length)) > 0)
                writeStream.Write(buffer, 0, bytes);

            writeStream.Flush();
        }

        sw.Stop();
        Console.WriteLine((buffered ? "Buffered" : "Normal") + " Time: " + sw.ElapsedMilliseconds + " ms");
    }

    static void Main()
    {
        Console.Write("Enter source file path: ");
        string src = Console.ReadLine();

        CopyFile(src, "normal_copy.dat", false);
        CopyFile(src, "buffered_copy.dat", true);
    }
}
