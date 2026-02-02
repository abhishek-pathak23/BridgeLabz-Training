using System;
using Newtonsoft.Json.Linq;
using System.IO;

class ReadJson
{
    static void Main()
    {
        string json = File.ReadAllText("users.json");
        JArray users = JArray.Parse(json);

        foreach (var u in users)
        {
            Console.WriteLine($"{u["name"]} - {u["email"]}");
        }
    }
}
