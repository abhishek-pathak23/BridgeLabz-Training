using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class CsvToJson
{
    static void Main()
    {
        var lines = File.ReadAllLines("data.csv");
        var headers = lines[0].Split(',');

        var list = new List<Dictionary<string,string>>();

        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            var obj = new Dictionary<string,string>();

            for (int j = 0; j < headers.Length; j++)
                obj[headers[j]] = values[j];

            list.Add(obj);
        }

        File.WriteAllText("data.json",
            JsonConvert.SerializeObject(list, Formatting.Indented));
    }
}
