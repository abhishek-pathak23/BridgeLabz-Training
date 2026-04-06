using System;
using Newtonsoft.Json.Linq;

class StudentJsonDemo
{
    static void Main()
    {
        JObject student = new JObject
        {
            ["name"] = "Ankit",
            ["age"] = 22,
            ["subjects"] = new JArray
            {
                "Maths",
                "Physics",
                "Computer Science"
            }
        };

        Console.WriteLine(student.ToString());
    }
}
