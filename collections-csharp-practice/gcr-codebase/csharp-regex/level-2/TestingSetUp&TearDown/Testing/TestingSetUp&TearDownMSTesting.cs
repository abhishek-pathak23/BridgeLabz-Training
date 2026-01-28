[TestClass]
public class FakeDatabaseTests
{
    private FakeDatabase db;

    [TestInitialize]
    public void ConnectDb()
    {
        db = new FakeDatabase();
        db.Connect();
    }

    [TestCleanup]
    public void DisconnectDb()
    {
        db.Disconnect();
    }

    [TestMethod]
    public void Database_IsConnected()
    {
        Assert.IsTrue(db.IsConnected);
    }
}