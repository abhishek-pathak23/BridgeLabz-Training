using System;

class BMICalculator
{
    // Calculate BMI
    public static void CalculateBMI(double[,] data)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            double heightInMeters = data[i,1] / 100;
            data[i,2] = data[i,0] / (heightInMeters * heightInMeters);
        }
    }

    // Determine BMI status
    public static string[] GetBMIStatus(double[,] data)
    {
        string[] status = new string[data.GetLength(0)];
        for (int i = 0; i < data.GetLength(0); i++)
            status[i] = data[i,2] < 18.5 ? "Underweight" :
                        data[i,2] < 25 ? "Normal" : "Overweight";

        return status;
    }

    static void Main()
    {
        double[,] persons = new double[10,3];

        for (int i = 0; i < 10; i++)
        {
            Console.Write("Enter weight: ");
            persons[i,0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter height (cm): ");
            persons[i,1] = Convert.ToDouble(Console.ReadLine());
        }

        CalculateBMI(persons);
        string[] status = GetBMIStatus(persons);

        for (int i = 0; i < 10; i++)
            Console.WriteLine($"BMI: {persons[i,2]} Status: {status[i]}");
    }
}
