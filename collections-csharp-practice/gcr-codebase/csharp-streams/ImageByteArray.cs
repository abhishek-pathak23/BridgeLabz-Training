using System;
using System.IO;

class ImageByteArray
{
    static void Main()
    {
        Console.Write("Enter image path: ");
        string src = Console.ReadLine();

        try
        {
            byte[] imageBytes = File.ReadAllBytes(src);

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                File.WriteAllBytes("copy_image.jpg", ms.ToArray());
            }

            Console.WriteLine("Image copied successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
