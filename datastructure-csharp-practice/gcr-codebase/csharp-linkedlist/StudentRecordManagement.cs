using System;

class StudentNode
{
    public int Roll;
    public string Name;
    public int Age;
    public string Grade;
    public StudentNode Next; // reference to next node
}

class StudentLinkedList
{
    StudentNode head = null; // starting point of the list

    public void AddAtEnd()
    {
        StudentNode node = new StudentNode();

        Console.Write("Roll: ");
        node.Roll = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        node.Name = Console.ReadLine();

        Console.Write("Age: ");
        node.Age = int.Parse(Console.ReadLine());

        Console.Write("Grade: ");
        node.Grade = Console.ReadLine();

        // if list is empty
        if (head == null)
        {
            head = node;
            return;
        }

        // move to last node
        StudentNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = node; // link new node
    }

    public void DeleteByRoll()
    {
        if (head == null) return; // empty list

        Console.Write("Enter Roll to delete: ");
        int roll = int.Parse(Console.ReadLine());

        // deleting first node
        if (head.Roll == roll)
        {
            head = head.Next;
            return;
        }

        StudentNode prev = head;
        StudentNode curr = head.Next;

        while (curr != null)
        {
            if (curr.Roll == roll)
            {
                prev.Next = curr.Next; // remove node
                return;
            }
            prev = curr;
            curr = curr.Next;
        }
    }

    public void Search()
    {
        Console.Write("Enter Roll to search: ");
        int roll = int.Parse(Console.ReadLine());

        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.Roll == roll)
            {
                Console.WriteLine($"{temp.Roll} {temp.Name} {temp.Age} {temp.Grade}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found");
    }

    public void Display()
    {
        StudentNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{temp.Roll} {temp.Name} {temp.Age} {temp.Grade}");
            temp = temp.Next;
        }
    }
}

class StudentRecordManagement
{
    static void Main()
    {
        StudentLinkedList list = new StudentLinkedList();

        while (true)
        {
            Console.WriteLine("1. Add\n2. Delete\n3. Search\n4. Display\n0. Exit");
            int ch = int.Parse(Console.ReadLine());

            if (ch == 0) break;

            if (ch == 1) list.AddAtEnd();
            if (ch == 2) list.DeleteByRoll();
            if (ch == 3) list.Search();
            if (ch == 4) list.Display();
        }
    }
}
