using System;

class Book
{
    public string title;
    public string author;
    public double price;

    public Book() // Default constructor
    {
        title = "Harry Potter";
        author = "JK Rowling";
        price = 1500;
    }

    public Book(string t, string a, double p) // Parameterized constructor
    {
        title = t;
        author = a;
        price = p;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {title}, Author: {author}, Price: {price}");
    }
}

class Program1
{
    static void Main()
    {
        Console.WriteLine("Enter Book Details for Parameterized Book:");
        Console.Write("Title: "); string t = Console.ReadLine();
        Console.Write("Author: "); string a = Console.ReadLine();
        Console.Write("Price: "); double p = Convert.ToDouble(Console.ReadLine());

        Book defaultBook = new Book();
        Book parameterBook = new Book(t, a, p);

        Console.WriteLine("\nDefault Book:");
        defaultBook.Display();
        Console.WriteLine("Parameterized Book:");
        parameterBook.Display();
    }
}
