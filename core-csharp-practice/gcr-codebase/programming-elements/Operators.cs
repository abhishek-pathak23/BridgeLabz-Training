using System;

class Operators
{
    static void Main()
    {

        Console.WriteLine(" All operators demonstrated successfully!");
        // 1. Arithmetic Operators

        int a = 15, b = 7;
		Console.WriteLine("Value of a is:" + a);
		Console.WriteLine("Value of b is:" + b);

        int add = a + b;                  // Addition
        Console.WriteLine("Addition: " + add);

        int sub = a - b;                  // Subtraction
        Console.WriteLine("Subtraction: " + sub);

        int mul = a * b;                  // Multiplication
        Console.WriteLine("Multiplication: " + mul);

        int div = a / b;                  // Division
        Console.WriteLine("Division: " + div);

        int mod = a % b;                  // Modulus
        Console.WriteLine("Modulus: " + mod);
        Console.WriteLine();

        // 2. Relational Operators

        bool equalTo = a == b;            // Equal to
        Console.WriteLine("Equal to (a == b): " + equalTo);

        bool notEqualTo = a != b;         // Not equal to
        Console.WriteLine("Not equal to (a != b): " + notEqualTo);

        bool greaterThan = a > b;         // Greater than
        Console.WriteLine("Greater than (a > b): " + greaterThan);

        bool lessThan = a < b;            // Less than
        Console.WriteLine("Less than (a < b): " + lessThan);

        bool greaterThanEqual = a >= b;   // Greater than or equal
        Console.WriteLine("Greater than or equal (a >= b): " + greaterThanEqual);

        bool lessThanEqual = a <= b;      // Less than or equal
        Console.WriteLine("Less than or equal (a <= b): " + lessThanEqual);
        Console.WriteLine();


        // 3. Logical Operators

        bool andOperator = (a > 5) && (b > 1);  // AND
        Console.WriteLine("Logical AND ((a > 5) && (b > 1)): " + andOperator);

        bool orOperator = (a > 20) || (b > 1);  // OR
        Console.WriteLine("Logical OR ((a > 20) || (b > 1)): " + orOperator);

        bool notOperator = !(a < b);            // NOT
        Console.WriteLine("Logical NOT (!(a < b)): " + notOperator);
        Console.WriteLine();


        // 4. Assignment Operators

        int x = 5;

        x += 2; Console.WriteLine("x += 2: " + x);
        x -= 1; Console.WriteLine("x -= 1: " + x);
        x *= 2; Console.WriteLine("x *= 2: " + x);
        x /= 2; Console.WriteLine("x /= 2: " + x);
        x %= 2; Console.WriteLine("x %= 2: " + x);
        Console.WriteLine();


        // 5. Unary Operators

        int y = 10;

        y++; Console.WriteLine("y++: " + y);
        y--; Console.WriteLine("y--: " + y);
        int pos = +y; Console.WriteLine("+y : " + pos);
        int neg = -y; Console.WriteLine("-y : " + neg);
        Console.WriteLine();

 
        // 6. Ternary Operator

        int marks = 40;

        string examResult = (marks >= 35) ? "Pass" : "Fail";
        Console.WriteLine("Result: " + examResult);
        Console.WriteLine();

        // 7. is Operator

        object obj = "Hello";

        bool isString = obj is string;
        Console.WriteLine("obj is string: " + isString);
        Console.WriteLine();

    }
}
