using System;
using System.IO;

public static class ExceptionLogger
{
    private static readonly string logFile = "exceptions.log";

    public static void Log(Exception ex)
    {
        using (StreamWriter writer = new StreamWriter(logFile, true))
        {
            writer.WriteLine("==========");
            writer.WriteLine(DateTime.Now);
            writer.WriteLine(ex.GetType().Name);
            writer.WriteLine(ex.Message);
            writer.WriteLine(ex.StackTrace);
            writer.WriteLine("==========");
        }
    }
}
