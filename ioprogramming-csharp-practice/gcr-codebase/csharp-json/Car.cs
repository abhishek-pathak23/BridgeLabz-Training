using System;
using Newtonsoft.Json;

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Price { get; set; }
}

class Program
{
    static void Main()
    {
        Car car = new Car
        {
            Brand = "Toyota",
            Model = "Fortuner",
            Price = 4500000
        };

        string json = JsonConvert.SerializeObject(car, Formatting.Indented);
        Console.WriteLine(json);
    }
}
