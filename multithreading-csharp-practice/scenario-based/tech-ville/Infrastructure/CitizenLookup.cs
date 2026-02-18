using System.Collections.Generic;

public class CitizenLookup
{
    private Dictionary<int, Citizen> citizens =
        new Dictionary<int, Citizen>();

    public void Add(Citizen citizen)
    {
        citizens[citizen.Id] = citizen;
    }

    public Citizen Get(int id)
    {
        return citizens.ContainsKey(id) ? citizens[id] : null;
    }
}
