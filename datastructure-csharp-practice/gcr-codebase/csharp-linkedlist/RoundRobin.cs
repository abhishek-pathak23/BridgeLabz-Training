using System;

// Node class for Circular Linked List
class ProcessNode
{
    // Process details
    public int ProcessId;
    public int BurstTime;
    public int RemainingTime;
    public int Priority;

    // Timing details
    public int WaitingTime;
    public int TurnAroundTime;

    // Pointer to next node
    public ProcessNode Next;

    // Constructor
    public ProcessNode(int pid, int burstTime, int priority)
    {
        ProcessId = pid;
        BurstTime = burstTime;
        RemainingTime = burstTime;
        Priority = priority;
        WaitingTime = 0;
        TurnAroundTime = 0;
        Next = null;
    }
}

// Circular Linked List for Round Robin Scheduling
class RoundRobinScheduler
{
    private ProcessNode head;
    private int processCount = 0;

    // Add process at end of circular list
    public void AddProcess(int pid, int burstTime, int priority)
    {
        ProcessNode newNode = new ProcessNode(pid, burstTime, priority);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
        }
        else
        {
            ProcessNode temp = head;
            while (temp.Next != head)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
            newNode.Next = head;
        }

        processCount++;
    }

    // Remove process by ID
    private void RemoveProcess(int pid)
    {
        if (head == null) return;

        ProcessNode curr = head;
        ProcessNode prev = null;

        do
        {
            if (curr.ProcessId == pid)
            {
                if (curr == head)
                {
                    ProcessNode temp = head;
                    while (temp.Next != head)
                    {
                        temp = temp.Next;
                    }

                    if (head.Next == head)
                    {
                        head = null;
                    }
                    else
                    {
                        head = head.Next;
                        temp.Next = head;
                    }
                }
                else
                {
                    prev.Next = curr.Next;
                }

                processCount--;
                return;
            }

            prev = curr;
            curr = curr.Next;

        } while (curr != head);
    }

    // Simulate Round Robin Scheduling
    public void Execute(int timeQuantum)
    {
        if (head == null)
        {
            Console.WriteLine("No processes to schedule");
            return;
        }

        int currentTime = 0;
        ProcessNode curr = head;

        Console.WriteLine("Round Robin Execution Started\n");

        while (processCount > 0)
        {
            DisplayProcesses();

            if (curr.RemainingTime > timeQuantum)
            {
                curr.RemainingTime -= timeQuantum;
                currentTime += timeQuantum;
            }
            else
            {
                currentTime += curr.RemainingTime;
                curr.RemainingTime = 0;
                curr.TurnAroundTime = currentTime;
                curr.WaitingTime = curr.TurnAroundTime - curr.BurstTime;

                int finishedPid = curr.ProcessId;
                curr = curr.Next;
                RemoveProcess(finishedPid);
                continue;
            }

            curr = curr.Next;
        }

        Console.WriteLine("\nScheduling completed");
    }

    // Display current process list
    public void DisplayProcesses()
    {
        if (head == null)
        {
            Console.WriteLine("Queue is empty\n");
            return;
        }

        ProcessNode temp = head;
        Console.WriteLine("Current Process Queue:");
        do
        {
            Console.WriteLine("PID: " + temp.ProcessId +
                              " | Remaining Time: " + temp.RemainingTime);
            temp = temp.Next;
        } while (temp != head);

        Console.WriteLine();
    }

    // Calculate average waiting and turn-around time
    public void CalculateAverageTimes(ProcessNode[] processes)
    {
        double totalWT = 0;
        double totalTAT = 0;

        foreach (var p in processes)
        {
            totalWT += p.WaitingTime;
            totalTAT += p.TurnAroundTime;
        }

        Console.WriteLine("\nAverage Waiting Time: " + (totalWT / processes.Length));
        Console.WriteLine("Average Turn-Around Time: " + (totalTAT / processes.Length));
    }
}

// Main class
class RoundRobin
{
    static void Main()
    {
        RoundRobinScheduler scheduler = new RoundRobinScheduler();

        // Add processes
        scheduler.AddProcess(1, 10, 1);
        scheduler.AddProcess(2, 5, 2);
        scheduler.AddProcess(3, 8, 1);

        int timeQuantum = 3;

        // Keep reference for calculation
        ProcessNode[] processes =
        {
            new ProcessNode(1,10,1),
            new ProcessNode(2,5,2),
            new ProcessNode(3,8,1)
        };

        // Execute scheduling
        scheduler.Execute(timeQuantum);

        // Calculate average times
        scheduler.CalculateAverageTimes(processes);
    }
}