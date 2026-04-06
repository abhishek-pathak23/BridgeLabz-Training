using System.Collections.Generic;

public class CitizenRegistry
{
    private List<Citizen> citizens = new List<Citizen>();

    public void AddCitizen(Citizen citizen)
    {
        citizens.Add(citizen);
    }

    public Citizen GetCitizen(int index)
    {
        return citizens[index]; // O(1) access
    }

    public void RemoveCitizen(Citizen citizen)
    {
        citizens.Remove(citizen);
    }

    public void AddAll(List<Citizen> newCitizens)
    {
        citizens.AddRange(newCitizens);
    }

    public void RemoveAll(List<Citizen> removeList)
    {
        citizens.RemoveAll(c => removeList.Contains(c));
    }

    public List<Citizen> GetAll()
    {
        return citizens;
    }
}
