using System;

// 1. Parent class
class Animal
{
    // Virtual method to allow overriding
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

// 2. Child class
class Dog : Animal
{
    // Override MakeSound method
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks: Woof Woof!");
    }
}

class Program
{
    static void Main()
    {
        // Optional: take input from user for demonstration
        Console.Write("Enter the type of animal to make sound (dog/animal): ");
        string input = Console.ReadLine().ToLower();

        Animal animal;

        // Instantiate based on user input
        if (input == "dog")
        {
            animal = new Dog();  // Dog overrides MakeSound
        }
        else
        {
            animal = new Animal();  // Base class method
        }

        // Call MakeSound (dynamic behavior if overridden)
        animal.MakeSound();
    }
}
