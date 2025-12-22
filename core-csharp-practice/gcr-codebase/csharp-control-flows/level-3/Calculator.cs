using System;

class Calculator
{
    static void Main()
    {
        double a,b;//take the inpt 
        string op;

        Console.WriteLine("Enter first number:");
        a=Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        b=Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter operator (+ - * /):");
        op=Console.ReadLine();

        switch(op) //check thr operator
        {
            case "+":
                Console.WriteLine("Result is "+(a+b));
                break;

            case "-":
                Console.WriteLine("Result is "+(a-b));
                break;

            case "*":
                Console.WriteLine("Result is "+(a*b));
                break;

            case "/":
                Console.WriteLine("Result is "+(a/b));
                break;

            default:
                Console.WriteLine("Invalid operator");
                break;
        }
    }
}
