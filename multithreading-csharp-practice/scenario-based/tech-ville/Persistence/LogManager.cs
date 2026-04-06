using System;
using System.IO;

public class LogManager
{
    private string logPath = "system.log";

    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logPath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
