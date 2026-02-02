using System;
using Newtonsoft.Json.Linq;

class MergeJson
{
    static void Main()
    {
        JObject j1 = JObject.Parse(@"{ 'name':'Ankit' }");
        JObject j2 = JObject.Parse(@"{ 'age':22 }");

        j1.Merge(j2);
        Console.WriteLine(j1);
    }
}
