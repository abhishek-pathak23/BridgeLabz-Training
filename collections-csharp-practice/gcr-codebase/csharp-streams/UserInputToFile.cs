using System;
using System.IO;

class UserInputToFile
{
    static void Main()
    {
        try
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            string age = Console.ReadLine();

            Console.Write("Favorite Programming Language: ");
            string lang = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter("user.txt"))
            {
                writer.WriteLine(name);
                writer.WriteLine(age);
                writer.WriteLine(lang);
            }

            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
