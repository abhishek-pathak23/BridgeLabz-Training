using System;

class TaskNode
{
    public int Id;
    public string Name, Priority;
    public TaskNode Next; // points to next task (circular)
}

class TaskCircularList
{
    TaskNode head = null; // starting point of the circular list

    public void AddTask()
    {
        TaskNode node = new TaskNode();

        Console.Write("ID: ");
        node.Id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        node.Name = Console.ReadLine();

        Console.Write("Priority: ");
        node.Priority = Console.ReadLine();

        // first task in the list
        if (head == null)
        {
            head = node;
            node.Next = head; // circular link
            return;
        }

        // move to last node
        TaskNode temp = head;
        while (temp.Next != head)
            temp = temp.Next;

        temp.Next = node;  // link last node to new node
        node.Next = head;  // maintain circular link
    }

    public void Display()
    {
        if (head == null) return;

        TaskNode temp = head;
        do
        {
            Console.WriteLine($"{temp.Id} {temp.Name} {temp.Priority}");
            temp = temp.Next;
        } while (temp != head); // stop when full circle is completed
    }
}

class TaskScheduler
{
    static void Main()
    {
        TaskCircularList list = new TaskCircularList();

        while (true)
        {
            Console.WriteLine("1 Add Task\n2 Display\n0 Exit"); // menu with new lines
            int ch = int.Parse(Console.ReadLine());

            if (ch == 0) break;
            if (ch == 1) list.AddTask();
            if (ch == 2) list.Display();
        }
    }
}
