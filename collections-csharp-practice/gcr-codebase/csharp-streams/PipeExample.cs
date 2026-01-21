using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class PipeExample
{
    static void Main()
    {
        using (AnonymousPipeServerStream server =
               new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
        using (AnonymousPipeClientStream client =
               new AnonymousPipeClientStream(PipeDirection.In, server.ClientSafePipeHandle))
        {
            Thread writerThread = new Thread(() =>
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(server))
                    {
                        sw.AutoFlush = true;
                        sw.WriteLine("Hello from writer thread");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Writer error: " + ex.Message);
                }
            });

            Thread readerThread = new Thread(() =>
            {
                try
                {
                    using (StreamReader sr = new StreamReader(client))
                    {
                        string message = sr.ReadLine();
                        Console.WriteLine("Received: " + message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Reader error: " + ex.Message);
                }
            });

            writerThread.Start();
            readerThread.Start();

            writerThread.Join();
            readerThread.Join();
        }
    }
}
