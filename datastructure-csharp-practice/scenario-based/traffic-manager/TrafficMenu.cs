using System;

namespace TrafficManager;

// Handles overall traffic operations combining roundabout and waiting queue
public class TrafficMenu : IRoundaboutManager
{
    private RoundaboutLinkedList roundabout;  // Circular linked list for roundabout vehicles
    private WaitingQueueUtility queue;         // Queue for waiting vehicles

    // Initialize roundabout and waiting queue with capacities
    public TrafficMenu(int roundCap, int queueCap)
    {
        roundabout = new RoundaboutLinkedList(roundCap);
        queue = new WaitingQueueUtility(queueCap);
    }

    // Enter a vehicle into the roundabout or waiting queue
    public void EnterVehicle(int vehicleNo)
    {
        if (!roundabout.IsFull())
        {
            roundabout.AddVehicle(vehicleNo);
            Console.WriteLine("Vehicle entered roundabout");
        }
        else
        {
            queue.Enqueue(vehicleNo);
            Console.WriteLine("Vehicle added to waiting queue");
        }
    }

    // Exit a vehicle from the roundabout and move a waiting vehicle in if available
    public void ExitVehicle()
    {
        roundabout.RemoveVehicle();

        if (!queue.IsEmpty())
        {
            int v = queue.Dequeue();
            roundabout.AddVehicle(v);
            Console.WriteLine("Vehicle moved from queue to roundabout");
        }
    }

    // Display current state of roundabout and waiting queue
    public void ShowTrafficStatus()
    {
        Console.WriteLine("\n--- Traffic Status ---");
        roundabout.Display();
        queue.Display();
    }
}
