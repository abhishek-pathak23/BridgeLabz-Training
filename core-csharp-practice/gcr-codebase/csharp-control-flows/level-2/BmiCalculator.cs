using System;

class BmiCalculator
{
    static void Main()
    {
        double weight,heightCm,heightM,bmi;//initialize the variables 

        Console.WriteLine("Enter weight in kg:");
        weight=Convert.ToDouble(Console.ReadLine());// take input of weigth 

        Console.WriteLine("Enter height in cm:");
        heightCm=Convert.ToDouble(Console.ReadLine());//take the input of height 

        heightM=heightCm/100; // centimeter to meter
        bmi=weight/(heightM*heightM);//formalue

        Console.WriteLine("BMI is "+bmi);

        if(bmi<18.5)
        {
            Console.WriteLine("Underweight");
        }
        else if(bmi<25)
        {
            Console.WriteLine("Normal weight");
        }
        else if(bmi<30)
        {
            Console.WriteLine("Overweight");
        }
        else
        {
            Console.WriteLine("Obese");
        }
    }
}
