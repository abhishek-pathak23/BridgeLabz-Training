using System.Collections.Generic;
using System.IO;

public class CsvParser
{
    public List<string[]> Parse(string filePath)
    {
        var result = new List<string[]>();

        using (StreamReader reader = new StreamReader(filePath, System.Text.Encoding.UTF8))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                result.Add(line.Split(','));
            }
        }

        return result;
    }
}
