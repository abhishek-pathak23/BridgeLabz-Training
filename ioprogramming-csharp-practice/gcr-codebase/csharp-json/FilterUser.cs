using System;
using Newtonsoft.Json.Linq;

class FilterUser
{
    static void Main()
    {
        JArray users = JArray.Parse(File.ReadAllText("users.json"));

        foreach (var u in users)
            if ((int)u["age"] > 25)
                Console.WriteLine(u);
    }
}
