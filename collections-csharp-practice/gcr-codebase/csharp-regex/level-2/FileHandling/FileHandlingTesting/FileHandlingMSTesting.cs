[TestClass]
public class FileHandlerTests
{
    private string filePath = "testfile.txt";
    private FileHandler handler = new FileHandler();

    [TestMethod]
    public void WriteAndRead_FileWorks()
    {
        handler.WriteToFile(filePath, "Hello MSTest");
        Assert.IsTrue(File.Exists(filePath));
        Assert.AreEqual("Hello MSTest", handler.ReadFromFile(filePath));
    }

    [TestMethod]
    [ExpectedException(typeof(IOException))]
    public void Read_NonExistingFile_ThrowsException()
    {
        handler.ReadFromFile("nofile.txt");
    }
}