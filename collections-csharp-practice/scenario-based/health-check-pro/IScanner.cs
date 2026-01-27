using System.Collections.Generic;

public interface IScanner
{
    List<APIMethod> ScanControllers();
    void GenerateDocumentation(string filePath);
}
