using System;

// Meal interface
interface IMealPlan
{
    string GetMeal();
}

// Vegetarian meal
class VegetarianMeal : IMealPlan
{
    public string GetMeal()
    {
        return "Vegetarian Meal Selected";
    }
}

// Vegan meal
class VeganMeal : IMealPlan
{
    public string GetMeal()
    {
        return "Vegan Meal Selected";
    }
}

// Keto meal
class KetoMeal : IMealPlan
{
    public string GetMeal()
    {
        return "Keto Meal Selected";
    }
}

// High protein meal
class HighProteinMeal : IMealPlan
{
    public string GetMeal()
    {
        return "High-Protein Meal Selected";
    }
}

// Generic meal generator with constraints
class Meal<T> where T : IMealPlan, new()
{
    public void Generate()
    {
        T meal = new T();
        Console.WriteLine(meal.GetMeal());
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Vegetarian");
        Console.WriteLine("2. Vegan");
        Console.WriteLine("3. Keto");
        Console.WriteLine("4. High Protein");
        Console.Write("Select Meal: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                new Meal<VegetarianMeal>().Generate();
                break;

            case 2:
                new Meal<VeganMeal>().Generate();
                break;

            case 3:
                new Meal<KetoMeal>().Generate();
                break;

            case 4:
                new Meal<HighProteinMeal>().Generate();
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
