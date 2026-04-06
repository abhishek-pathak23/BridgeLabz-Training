using System;

// Node class for ticket
class TicketNode
{
    public int TicketID;
    public string CustomerName;
    public string MovieName;
    public int SeatNumber;
    public string BookingTime;

    public TicketNode Next;

    public TicketNode(int id, string customer, string movie, int seat, string time)
    {
        TicketID = id;
        CustomerName = customer;
        MovieName = movie;
        SeatNumber = seat;
        BookingTime = time;
        Next = null;
    }
}

// Circular Linked List class
class TicketReservationSystem
{
    private TicketNode head = null;
    private TicketNode tail = null;

    // Add ticket at end
    public void AddTicket(int id, string customer, string movie, int seat, string time)
    {
        TicketNode newNode = new TicketNode(id, customer, movie, seat, time);

        // If list is empty
        if (head == null)
        {
            head = tail = newNode;
            tail.Next = head; // circular link
            return;
        }

        tail.Next = newNode;
        tail = newNode;
        tail.Next = head; // maintain circular nature
    }

    // Remove ticket by Ticket ID
    public void RemoveTicket(int id)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets to remove");
            return;
        }

        TicketNode current = head;
        TicketNode previous = tail;

        do
        {
            if (current.TicketID == id)
            {
                // If only one ticket
                if (current == head && current == tail)
                {
                    head = tail = null;
                }
                else
                {
                    previous.Next = current.Next;
                    if (current == head)
                        head = head.Next;
                    if (current == tail)
                        tail = previous;
                }

                Console.WriteLine("Ticket removed successfully");
                return;
            }

            previous = current;
            current = current.Next;

        } while (current != head);

        Console.WriteLine("Ticket not found");
    }

    // Display all tickets
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked");
            return;
        }

        TicketNode temp = head;
        Console.WriteLine("\nBooked Tickets:");
        do
        {
            Console.WriteLine(
                "ID: " + temp.TicketID +
                ", Customer: " + temp.CustomerName +
                ", Movie: " + temp.MovieName +
                ", Seat: " + temp.SeatNumber +
                ", Time: " + temp.BookingTime
            );
            temp = temp.Next;
        } while (temp != head);
    }

    // Search by Customer Name or Movie Name
    public void SearchTicket(string keyword)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets to search");
            return;
        }

        TicketNode temp = head;
        bool found = false;

        do
        {
            if (temp.CustomerName.Equals(keyword, StringComparison.OrdinalIgnoreCase) ||
                temp.MovieName.Equals(keyword, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    "ID: " + temp.TicketID +
                    ", Customer: " + temp.CustomerName +
                    ", Movie: " + temp.MovieName +
                    ", Seat: " + temp.SeatNumber +
                    ", Time: " + temp.BookingTime
                );
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No matching ticket found");
    }

    // Count total booked tickets
    public int CountTickets()
    {
        if (head == null)
            return 0;

        int count = 0;
        TicketNode temp = head;

        do
        {
            count++;
            temp = temp.Next;
        } while (temp != head);

        return count;
    }
}

// Main class
class TicketReservationSys
{
    static void Main()
    {
        TicketReservationSystem system = new TicketReservationSystem();

        system.AddTicket(101, "Aditya", "Inception", 12, "10:30 AM");
        system.AddTicket(102, "Rohit", "Avatar", 18, "01:00 PM");
        system.AddTicket(103, "Neha", "Inception", 22, "04:00 PM");

        system.DisplayTickets();

        Console.WriteLine("\nSearch Ticket by Movie Name:");
        system.SearchTicket("Inception");

        Console.WriteLine("\nTotal Tickets Booked: " + system.CountTickets());

        Console.WriteLine("\nRemoving Ticket ID 102");
        system.RemoveTicket(102);

        system.DisplayTickets();
    }
}