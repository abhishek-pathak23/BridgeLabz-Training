using System;
using System.Collections.Generic;
using Newtonsoft.Json;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> list = new()
        {
            new Employee{Id=1,Name="A"},
            new Employee{Id=2,Name="B"}
        };

        Console.WriteLine(JsonConvert.SerializeObject(list, Formatting.Indented));
    }
}
