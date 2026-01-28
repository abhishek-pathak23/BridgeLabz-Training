using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TemperatureConverterTests
{
    private TemperatureConverter converter;

    [TestInitialize]
    public void Init()
    {
        converter = new TemperatureConverter();
    }

    [TestMethod]
    public void CelsiusToFahrenheit_WorksCorrectly()
    {
        Assert.AreEqual(32, converter.CelsiusToFahrenheit(0));
    }

    [TestMethod]
    public void FahrenheitToCelsius_WorksCorrectly()
    {
        Assert.AreEqual(0, converter.FahrenheitToCelsius(32));
    }
}