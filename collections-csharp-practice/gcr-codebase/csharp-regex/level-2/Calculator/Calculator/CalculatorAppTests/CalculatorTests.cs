using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;
using System;

namespace CalculatorAppTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            int result = calc.Add(10, 5);

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            Calculator calc = new Calculator();
            int result = calc.Subtract(10, 5);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            Calculator calc = new Calculator();
            int result = calc.Multiply(10, 5);
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            Calculator calc = new Calculator();
            int result = calc.Divide(10, 5);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Divide_ByZero_ShouldThrowException()
        {
            // Arrange
            Calculator calc = new Calculator();

            try
            {
                // Act
                calc.Divide(10, 0);

                // If exception is not thrown, fail the test
                Assert.Fail("Expected DivideByZeroException was not thrown");
            }
            catch (DivideByZeroException)
            {
                // Assert
                // Test passes because exception is thrown
                Assert.IsTrue(true);
            }
        }
    }
}
