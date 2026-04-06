using System.IO;

public class PhotoManager
{
    public byte[] UploadPhoto(string path)
    {
        return File.ReadAllBytes(path);
    }

    public void SavePhoto(byte[] data, string outputPath)
    {
        File.WriteAllBytes(outputPath, data);
    }
}
