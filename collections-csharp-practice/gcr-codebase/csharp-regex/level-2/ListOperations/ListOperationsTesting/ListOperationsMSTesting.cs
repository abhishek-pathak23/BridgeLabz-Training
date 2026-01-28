[TestClass]
public class IntegerListHandlerTests
{
    private List<int> numbers;
    private IntegerListHandler manager;

    [TestInitialize]
    public void Setup()
    {
        numbers = new List<int>();
        manager = new IntegerListHandler();
    }

    [TestMethod]
    public void AddElement_IncreasesSize()
    {
        manager.AddElement(numbers, 5);
        Assert.AreEqual(1, manager.GetSize(numbers));
    }

    [TestMethod]
    public void RemoveElement_DecreasesSize()
    {
        numbers.Add(10);
        manager.RemoveElement(numbers, 10);
        Assert.AreEqual(0, manager.GetSize(numbers));
    }
}