using System.IO;

public class RegistrationWriter
{
    private string path = "registrations.txt";

    public void WriteRegistration(Citizen citizen)
    {
        using (StreamWriter writer = new StreamWriter(path, true)) // append mode
        {
            writer.WriteLine(citizen.ToString());
        }
    }
}
