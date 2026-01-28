using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TaskSimulatorTests
{
    [TestMethod]
    [Timeout(2000)] // 2 seconds
    public void LongRunningTask_ShouldFail()
    {
        TaskSimulator sim = new TaskSimulator();
        sim.LongRunningTask();
    }
}