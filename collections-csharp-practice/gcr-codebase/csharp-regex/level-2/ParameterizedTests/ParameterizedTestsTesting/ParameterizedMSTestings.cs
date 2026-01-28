[TestClass]
public class NumberUtilityTests
{
    private NumberUtility util = new NumberUtility();

    [DataTestMethod]
    [DataRow(2, true)]
    [DataRow(4, true)]
    [DataRow(6, true)]
    [DataRow(7, false)]
    [DataRow(9, false)]
    public void IsEven_ReturnsExpectedResult(int input, bool expected)
    {
        Assert.AreEqual(expected, util.IsEven(input));
    }
}