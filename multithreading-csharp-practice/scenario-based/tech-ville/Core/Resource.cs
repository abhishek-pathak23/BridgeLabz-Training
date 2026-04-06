public class Resource
{
    private int resourceId;
    private string resourceName;

    public Resource(int id, string name)
    {
        resourceId = id;
        resourceName = name;
    }

    public override string ToString()
    {
        return $"Resource ID: {resourceId}, Name: {resourceName}";
    }
}
