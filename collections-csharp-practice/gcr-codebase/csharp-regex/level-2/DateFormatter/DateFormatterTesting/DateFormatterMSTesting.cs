using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class DateFormatterTests
{
    private DateFormatter formatter;

    [TestInitialize]
    public void Setup()
    {
        formatter = new DateFormatter();
    }

    [TestMethod]
    public void ValidDate_FormatsCorrectly()
    {
        string result = formatter.FormatDate("2024-01-15");
        Assert.AreEqual("15-01-2024", result);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void InvalidDate_ThrowsException()
    {
        formatter.FormatDate("15-01-2024");
    }
}