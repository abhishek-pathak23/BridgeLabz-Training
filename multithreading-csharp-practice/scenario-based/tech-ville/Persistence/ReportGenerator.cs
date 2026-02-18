using System.Collections.Generic;
using System.IO;

public class ReportGenerator
{
    public void GenerateCitizenReport(List<Citizen> citizens)
    {
        using (StreamWriter writer = new StreamWriter("citizen_report.txt"))
        {
            foreach (var citizen in citizens)
            {
                writer.WriteLine(citizen.ToString());
            }
        }
    }
}
