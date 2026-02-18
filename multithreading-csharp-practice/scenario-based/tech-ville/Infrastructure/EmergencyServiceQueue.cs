using System.Collections.Generic;

public class EmergencyServiceQueue
{
    private PriorityQueue<Service, int> priorityQueue =
        new PriorityQueue<Service, int>();

    public void Enqueue(Service service, int priority)
    {
        priorityQueue.Enqueue(service, priority);
    }

    public Service Dequeue()
    {
        return priorityQueue.Count > 0 ? priorityQueue.Dequeue() : null;
    }
}
