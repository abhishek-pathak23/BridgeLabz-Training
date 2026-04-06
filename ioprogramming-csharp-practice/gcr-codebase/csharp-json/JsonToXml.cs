using System;
using Newtonsoft.Json;
using System.Xml;

class JsonToXml
{
    static void Main()
    {
        string json = File.ReadAllText("data.json");
        XmlDocument xml = JsonConvert.DeserializeXmlNode(json, "Root");

        xml.Save("data.xml");
    }
}
