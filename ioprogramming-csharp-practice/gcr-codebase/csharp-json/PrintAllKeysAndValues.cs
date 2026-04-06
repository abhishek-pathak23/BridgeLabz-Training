using System;
using Newtonsoft.Json.Linq;

class PrintAllKeysAndValues
{
    static void Print(JToken token)
    {
        if (token is JProperty p)
            Console.WriteLine($"{p.Name} : {p.Value}");

        foreach (var child in token.Children())
            Print(child);
    }

    static void Main()
    {
        JObject obj = JObject.Parse(File.ReadAllText("data.json"));
        Print(obj);
    }
}
