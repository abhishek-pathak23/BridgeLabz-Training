using System.Collections.Generic;

public class ServiceRequestQueue
{
    private Queue<Service> queue = new Queue<Service>();

    public void Enqueue(Service service)
    {
        queue.Enqueue(service);
    }

    public Service Dequeue()
    {
        if (queue.Count > 0)
            return queue.Dequeue();

        return null;
    }

    public int Count()
    {
        return queue.Count;
    }
}
