using System;

class Circle
{
    public double radius;

    public Circle() : this(1) // Default radius 1 using constructor chaining
    {
    }

    public Circle(double r) // Parameterized constructor
    {
        radius = r;
    }

    public double Area()
    {
        return Math.PI * radius * radius;
    }

    public void Display()
    {
        Console.WriteLine($"Circle Radius: {radius}, Area: {Area():F2}");
    }
}

class CircleRadius
{
    static void Main()
    {
        Console.WriteLine("Enter Circle Radius:");
        double r = Convert.ToDouble(Console.ReadLine());

        Circle defaultCircle = new Circle();
        Circle userCircle = new Circle(r);

        Console.WriteLine("\nDefault Circle:");
        defaultCircle.Display();
        Console.WriteLine("User Circle:");
        userCircle.Display();
    }
}
