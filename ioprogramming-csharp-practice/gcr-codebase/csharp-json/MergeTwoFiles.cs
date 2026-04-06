using System;
using Newtonsoft.Json.Linq;
using System.IO;

class MergeTwoFiles
{
    static void Main()
    {
        JObject j1 = JObject.Parse(File.ReadAllText("file1.json"));
        JObject j2 = JObject.Parse(File.ReadAllText("file2.json"));

        j1.Merge(j2);
        File.WriteAllText("merged.json", j1.ToString());
    }
}
