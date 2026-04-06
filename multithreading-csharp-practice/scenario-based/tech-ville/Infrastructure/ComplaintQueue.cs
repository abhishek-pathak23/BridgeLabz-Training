using System.Collections.Generic;

public class ComplaintQueue
{
    private LinkedList<Complaint> complaints = new LinkedList<Complaint>();

    public void AddFirst(Complaint complaint)
    {
        complaints.AddFirst(complaint);
    }

    public void AddLast(Complaint complaint)
    {
        complaints.AddLast(complaint);
    }

    public void RemoveFirst()
    {
        if (complaints.Count > 0)
            complaints.RemoveFirst();
    }

    public IEnumerable<Complaint> GetAll()
    {
        return complaints;
    }
}
