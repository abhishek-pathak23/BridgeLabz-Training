public class Complaint
{
    private int complaintId;
    private string description;

    public Complaint(int id, string desc)
    {
        complaintId = id;
        description = desc;
    }

    public override string ToString()
    {
        return $"Complaint ID: {complaintId}, Description: {description}";
    }
}
