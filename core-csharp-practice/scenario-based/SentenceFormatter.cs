//Program does the following:
//Formats a paragraph by removing extra spaces and ensuring only one space between words and after punctuation (., ?, !).
//Capitalizes the first letter of each sentence automatically.
//Provides a menu-driven interface allowing the user to format multiple paragraphs or exit the program
using System;

class SentenceFormatter
{
    string paragraph;

    // Constructor
    SentenceFormatter(string paragraph)
    {
        this.paragraph = paragraph;
    }

    // Method to format the sentence
    string Format()
    {
        char[] arr = new char[paragraph.Length * 2];
        int index = 0;

        bool capital = true;
        bool space = false;

        for (int i = 0; i < paragraph.Length; i++)
        {
            char ch = paragraph[i];
            switch (ch)
            {
                case ' ':
                    if (space)
                    {
                        arr[index++] = ' ';
                        space = false;
                    }
                    break;
                case '.':
                case '?':
                case '!':
                    arr[index++] = ch;
                    arr[index++] = ' ';
                    capital = true;
                    space = false;
                    break;
                default:
                    if (capital && ch >= 'a' && ch <= 'z')
                        ch = (char)(ch - 32);
                    capital = false;
                    arr[index++] = ch;
                    space = true;
                    break;
            }
        }

        int len = index;
        if (len > 0 && arr[len - 1] == ' ')
            len--;

        char[] finalArr = new char[len];
        for (int i = 0; i < len; i++)
            finalArr[i] = arr[i];

        return new string(finalArr);
    }

    // Program logic inside the same class
    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\n--- Sentence Formatter Menu ---");
            Console.WriteLine("1. Format a paragraph");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input! Enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the paragraph: ");
                    string paragraph = Console.ReadLine();

                    // Create object and call Format (works because Main is inside the class)
                    SentenceFormatter formatter = new SentenceFormatter(paragraph);
                    string formatted = formatter.Format();

                    Console.WriteLine("\nFormatted Paragraph:");
                    Console.WriteLine(formatted);
                    break;

                case 2:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }

        } while (choice != 2);
    }
}
