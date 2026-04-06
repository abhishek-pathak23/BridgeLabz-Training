using System;
using System.Collections.Generic;
using Newtonsoft.Json;

class DatabaseRecords
{
    static void Main()
    {
        var dbData = new[]
        {
            new { Id=1, Name="A", Salary=50000 },
            new { Id=2, Name="B", Salary=60000 }
        };

        File.WriteAllText("report.json",
            JsonConvert.SerializeObject(dbData, Formatting.Indented));
    }
}
