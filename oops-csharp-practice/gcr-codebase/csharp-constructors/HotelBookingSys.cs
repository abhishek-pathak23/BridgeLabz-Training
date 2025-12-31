using System;

class HotelBooking
{
    public string guestName;
    public string roomType;
    public int nights;

    public HotelBooking() // Default
    {
        guestName = "Aman";
        roomType = "Standard";
        nights = 1;
    }

    public HotelBooking(string g, string r, int n) // Parameterized
    {
        guestName = g;
        roomType = r;
        nights = n;
    }

    public HotelBooking(HotelBooking h) // Copy constructor
    {
        guestName = h.guestName;
        roomType = h.roomType;
        nights = h.nights;
    }

    public void Display()
    {
        Console.WriteLine($"Guest: {guestName}, Room: {roomType}, Nights: {nights}");
    }
}

class HotelBookingSys
{
    static void Main()
    {
        Console.WriteLine("Enter Booking Details:");
        Console.Write("Guest Name: "); string g = Console.ReadLine();
        Console.Write("Room Type: "); string r = Console.ReadLine();
        Console.Write("Number of Nights: "); int n = Convert.ToInt32(Console.ReadLine());

        HotelBooking defaultBooking = new HotelBooking();
        HotelBooking userBooking = new HotelBooking(g, r, n);
        HotelBooking copyBooking = new HotelBooking(userBooking);

        Console.WriteLine("\nDefault Booking:");
        defaultBooking.Display();
        Console.WriteLine("User Booking:");
        userBooking.Display();
        Console.WriteLine("Copied Booking:");
        copyBooking.Display();
    }
}
