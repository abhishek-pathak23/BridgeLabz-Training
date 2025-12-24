using System;

class QuadraticEqn
{
    // Find roots of quadratic equation ax^2 + bx + c = 0
    public static double[] FindRoots(double a, double b, double c)
    {
        double delta = Math.Pow(b, 2) - 4 * a * c;

        if (delta < 0) return new double[0]; // No real roots
        if (delta == 0) return new double[] { -b / (2 * a) }; // One root

        double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
        double root2 = (-b - Math.Sqrt(delta)) / (2 * a);

        return new double[] { root1, root2 };
    }

    static void Main()
    {
        Console.Write("Enter coefficient a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter coefficient b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter coefficient c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        double[] roots = FindRoots(a, b, c);

        if (roots.Length == 0)
        {
            Console.WriteLine("No real roots exist.");
        }
        else
        {
            foreach (double r in roots)
                Console.WriteLine("Root: " + r);
        }
    }
}
