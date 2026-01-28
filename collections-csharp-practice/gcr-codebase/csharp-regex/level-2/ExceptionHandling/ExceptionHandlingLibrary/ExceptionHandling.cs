using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class ArithmeticTests
{
    [TestMethod]
    [ExpectedException(typeof(ArithmeticException))]
    public void Divide_ThrowsArithmeticException()
    {
        int a = 10;
        int b = 0;
        int result = a / b; // throws ArithmeticException
    }
}