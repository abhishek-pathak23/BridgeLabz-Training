using System.Collections.Generic;

public interface IScannerI
{
    List<EventLog> ScanClasses();
    void GenerateJSON(string filePath);
}
