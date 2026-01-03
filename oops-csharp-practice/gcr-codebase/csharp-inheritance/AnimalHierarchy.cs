using System;

// Superclass
class Animal
{
    public string Name;
    public int Age;

    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }
}

class Bird : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bird chirps");
    }
}

class AnimalHierarchy
{
    static void Main()
    {
        Console.WriteLine("Enter Animal Type (Dog/Cat/Bird): ");
        string type = Console.ReadLine();

        Animal animal;

        if (type == "Dog") animal = new Dog();
        else if (type == "Cat") animal = new Cat();
        else animal = new Bird();

        Console.Write("Enter Name: ");
        animal.Name = Console.ReadLine();

        Console.Write("Enter Age: ");
        animal.Age = int.Parse(Console.ReadLine());

        animal.MakeSound(); // Polymorphism
    }
}
