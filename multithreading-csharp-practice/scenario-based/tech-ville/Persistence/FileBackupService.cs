using System.IO;

public class FileBackupService
{
    public void CopyFile(string source, string destination)
    {
        File.Copy(source, destination, true);
    }
}
