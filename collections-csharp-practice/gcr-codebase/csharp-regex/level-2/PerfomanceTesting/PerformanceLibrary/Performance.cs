using System.Threading;

public class TaskSimulator
{
    public void LongRunningTask()
    {
        // Simulate long work (3 seconds)
        Thread.Sleep(3000);
    }
}