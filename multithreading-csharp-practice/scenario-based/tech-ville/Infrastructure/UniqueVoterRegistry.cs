using System.Collections.Generic;

public class UniqueVoterRegistry
{
    private HashSet<int> voterIds = new HashSet<int>();

    public bool AddVoter(int id)
    {
        return voterIds.Add(id); // false if duplicate
    }

    public bool Exists(int id)
    {
        return voterIds.Contains(id);
    }
}
