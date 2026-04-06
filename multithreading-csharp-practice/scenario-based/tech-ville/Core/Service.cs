public class Service
{
    private int serviceId;
    private string serviceName;

    public int ServiceId
    {
        get { return serviceId; }
        set { serviceId = value; }
    }

    public string ServiceName
    {
        get { return serviceName; }
        set { serviceName = value; }
    }

    public Service(int id, string name)
    {
        serviceId = id;
        serviceName = name;
    }

    public override string ToString()
    {
        return $"Service ID: {serviceId}, Name: {serviceName}";
    }
}
