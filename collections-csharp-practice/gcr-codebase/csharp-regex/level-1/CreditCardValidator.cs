using System;
using System.Text.RegularExpressions;

// This class validates Visa and MasterCard numbers
class CreditCardValidator
{
    static void Main()
    {
        // Ask user to enter credit card number
        Console.WriteLine("Enter Credit Card Number:");
        string cardNumber = Console.ReadLine();

        // Regex:
        // Visa    -> starts with 4, total 16 digits
        // Master  -> starts with 5, total 16 digits
        string pattern = @"^(4\d{15}|5\d{15})$";

        if (Regex.IsMatch(cardNumber, pattern))
        {
            Console.WriteLine("Valid Credit Card Number");
        }
        else
        {
            Console.WriteLine("Invalid Credit Card Number");
        }
    }
}
