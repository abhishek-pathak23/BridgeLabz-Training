using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

class ValidateJsonStructure
{
    static void Main()
    {
        JObject data = JObject.Parse(@"
        { 'name':'Ankit', 'age':22, 'email':'ankit@gmail.com' }");

        JSchema schema = JSchema.Parse(@"
        {
          'type':'object',
          'properties':{
            'name':{'type':'string'},
            'age':{'type':'number'},
            'email':{'type':'string','format':'email'}
          }
        }");

        Console.WriteLine(data.IsValid(schema));
    }
}
