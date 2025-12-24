using System;

class TrigonometryCalc
{
    // Returns sine, cosine, and tangent values
    public static double[] GetTrigonometricValues(double degreeAngle)
    {
        double radianValue = degreeAngle * Math.PI / 180;

        double sineValue = Math.Sin(radianValue);
        double cosineValue = Math.Cos(radianValue);
        double tangentValue = Math.Tan(radianValue);

        return new double[] { sineValue, cosineValue, tangentValue };
    }

    static void Main()
    {
        Console.Write("Enter angle in degrees: ");
        double degreeAngle = Convert.ToDouble(Console.ReadLine());

        double[] trigResults = GetTrigonometricValues(degreeAngle);
		
		//Result

        Console.WriteLine("Sine: " + trigResults[0]);
        Console.WriteLine("Cosine: " + trigResults[1]);
        Console.WriteLine("Tangent: " + trigResults[2]);
    }
}
