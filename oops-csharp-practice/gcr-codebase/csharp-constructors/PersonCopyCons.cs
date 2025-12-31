using System;

class Person
{
    public string name;
    public int age;

    public Person() // Default constructor
    {
        name = "Unknown";
        age = 0;
    }

    public Person(string n, int a) // Parameterized constructor
    {
        name = n;
        age = a;
    }

    // Copy constructor
    public Person(Person p)
    {
        name = p.name;
        age = p.age;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }
}

class PersonCopyCons
{
    static void Main()
    {
        Console.WriteLine("Enter Person Details:");
        Console.Write("Name: "); string n = Console.ReadLine();
        Console.Write("Age: "); int a = Convert.ToInt32(Console.ReadLine());

        Person original = new Person(n, a);
        Person copy = new Person(original);

        Console.WriteLine("\nOriginal Person:");
        original.Display();
        Console.WriteLine("Copied Person:");
        copy.Display();
    }
}
