using System;
using Newtonsoft.Json.Linq;
using System.Linq;

class ParseJson
{
    static void Main()
    {
        JArray users = JArray.Parse(File.ReadAllText("users.json"));

        var filtered = users.Where(u => (int)u["age"] > 25);

        foreach (var u in filtered)
            Console.WriteLine(u["name"]);
    }
}
