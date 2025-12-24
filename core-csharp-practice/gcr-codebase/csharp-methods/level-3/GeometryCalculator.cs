using System;

class GeometryCalculator
{
    // Calculate Euclidean distance
    public static double EuclideanDistance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    // Calculate line equation y = mx + b
    public static double[] LineEquation(double x1, double y1, double x2, double y2)
    {
        double m = (y2 - y1) / (x2 - x1); // slope
        double b = y1 - m * x1;           // y-intercept
        return new double[] { m, b };
    }

    static void Main()
    {
        Console.Write("Enter x1: "); double x1 = double.Parse(Console.ReadLine());
        Console.Write("Enter y1: "); double y1 = double.Parse(Console.ReadLine());
        Console.Write("Enter x2: "); double x2 = double.Parse(Console.ReadLine());
        Console.Write("Enter y2: "); double y2 = double.Parse(Console.ReadLine());

        double dist = EuclideanDistance(x1, y1, x2, y2);
        double[] eq = LineEquation(x1, y1, x2, y2);

        Console.WriteLine("Distance: " + dist);
        Console.WriteLine($"Line Equation: y = {eq[0]}x + {eq[1]}");
    }
}
