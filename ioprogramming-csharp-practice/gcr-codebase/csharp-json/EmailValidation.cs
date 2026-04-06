using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;

class EmailValidation
{
    static void Main()
    {
        JObject obj = JObject.Parse(@"{ 'email':'test@gmail.com' }");

        JSchema schema = JSchema.Parse(@"
        { 'type':'object',
          'properties':{
            'email':{'type':'string','format':'email'}
          }}");

        Console.WriteLine(obj.IsValid(schema));
    }
}
