using System.Collections.Generic;

public class SortedCitizenIndex
{
    private SortedSet<Citizen> citizens =
        new SortedSet<Citizen>();

    public void Add(Citizen citizen)
    {
        citizens.Add(citizen);
    }

    public IEnumerable<Citizen> GetAll()
    {
        return citizens;
    }
}
