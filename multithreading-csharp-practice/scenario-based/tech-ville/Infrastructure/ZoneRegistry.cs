using System.Collections.Generic;

public class ZoneRegistry
{
    private Dictionary<string, List<Citizen>> zones =
        new Dictionary<string, List<Citizen>>();

    public void AddCitizen(string zone, Citizen citizen)
    {
        if (!zones.ContainsKey(zone))
            zones[zone] = new List<Citizen>();

        zones[zone].Add(citizen);
    }

    public List<Citizen> GetZoneCitizens(string zone)
    {
        return zones.ContainsKey(zone) ? zones[zone] : null;
    }
}
