using System;

class DataTypes
{
    static void Main()
    {
	
	    Console.WriteLine("All data types and type casting demonstrated below!");
		
        // Integer (int)

        int intNum = 100;
        Console.WriteLine("Integer example: " + intNum);

        // Float

        float floatNum = 12.5f;
        Console.WriteLine("Float example: " + floatNum);

        // Double

        double doubleNum = 123.456;
        Console.WriteLine("Double example: " + doubleNum);

        // Char

        char character = 'A';
        Console.WriteLine("Char example: " + character);

        // Boolean

        bool isTrue = true;
        Console.WriteLine("Boolean example: " + isTrue);

        // ===========================
        // String
        // ===========================
        string name = "Abhishek";
        Console.WriteLine("String example: " + name);

        Console.WriteLine();
        Console.WriteLine("===== Type Casting Examples =====");

        // 7. Implicit Casting (smaller data type to larger data type)

        int smallInt = 50;
        double largeDouble = smallInt;    // Implicit casting
        Console.WriteLine("Implicit Casting (int to double): " + largeDouble);

        // 8. Explicit Casting (larger data type to smaller data type)

        double bigDouble = 123.45;
        int intFromDouble = (int)bigDouble;  // Explicit casting
        Console.WriteLine("Explicit Casting (double to int): " + intFromDouble);

        // 9. Using Convert class

        string strNumber = "200";
        int numFromString = Convert.ToInt32(strNumber);
        Console.WriteLine("Using Convert.ToInt32: " + numFromString);

        double doubleFromString = Convert.ToDouble("123.45");
        Console.WriteLine("Using Convert.ToDouble: " + doubleFromString);

        // 10. String to char array

        string sample = "Hello";
        char firstChar = sample[0];  
        Console.WriteLine("First character of \"" + sample + "\": " + firstChar);

        // 11. Numeric to String

        int num = 999;
        string strFromNum = num.ToString();
        Console.WriteLine("Integer to String: " + strFromNum);


        // 12. Char to Int ( Using ASCII value)

        char ch = 'B';
        int asciiValue = ch;  // Implicitly converts char to int (ASCII)
        Console.WriteLine("ASCII value of '" + ch + "': " + asciiValue);

        Console.WriteLine();

    }
}
