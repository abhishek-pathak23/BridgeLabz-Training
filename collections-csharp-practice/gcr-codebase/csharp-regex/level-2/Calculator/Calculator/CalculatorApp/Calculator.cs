using System;

namespace CalculatorApp
{
    public class Calculator
    {
        // Adds two numbers
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Subtracts second number from first
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        // Multiplies two numbers
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        // Divides first number by second
        // Throws DivideByZeroException if b is 0
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }

            return a / b;
        }
    }
}
