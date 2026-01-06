using System;

class CallLog
{
    public string PhoneNumber;
    public string Message;
    public DateTime Timestamp;
}

class CallLogManager
{
    private CallLog[] callLogs;
    private int count;

    public CallLogManager(int size)
    {
        callLogs = new CallLog[size];
        count = 0;
    }

    // Feature 1: Add Call Log
    public void AddCallLog()
    {
        if (count >= callLogs.Length)
        {
            Console.WriteLine(" Call log storage is full.");
            return;
        }

        Console.Write("Enter Phone Number: ");
        string phone = Console.ReadLine();

        Console.Write("Enter Message: ");
        string message = Console.ReadLine();

        Console.Write("Enter Date & Time (yyyy-MM-dd HH:mm): ");
        DateTime time = DateTime.Parse(Console.ReadLine());

        callLogs[count] = new CallLog
        {
            PhoneNumber = phone,
            Message = message,
            Timestamp = time
        };

        count++;
        Console.WriteLine(" Call log added successfully.");
    }

    // Feature 2: Search by Keyword
    public void SearchByKeyword()
    {
        Console.Write("Enter keyword to search: ");
        string keyword = Console.ReadLine();

        bool found = false;
        Console.WriteLine("\n Search Results:");
        for (int i = 0; i < count; i++)
        {
            if (callLogs[i].Message.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                DisplayLog(callLogs[i]);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine(" No matching records found.");
    }

    // Feature 3: Filter by Time Range
    public void FilterByTime()
    {
        Console.Write("Enter Start Date & Time (yyyy-MM-dd HH:mm): ");
        DateTime start = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter End Date & Time (yyyy-MM-dd HH:mm): ");
        DateTime end = DateTime.Parse(Console.ReadLine());

        bool found = false;
        Console.WriteLine("\n Filtered Call Logs:");
        for (int i = 0; i < count; i++)
        {
            if (callLogs[i].Timestamp >= start && callLogs[i].Timestamp <= end)
            {
                DisplayLog(callLogs[i]);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine(" No logs found in this time range.");
    }

    private void DisplayLog(CallLog log)
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Phone Number : {log.PhoneNumber}");
        Console.WriteLine($"Message      : {log.Message}");
        Console.WriteLine($"Timestamp    : {log.Timestamp}");
    }
}

class CallLogManage
{
    static void Main()
    {
        CallLogManager manager = new CallLogManager(20);
        int choice;

        do
        {
            Console.WriteLine("\n Customer Service Call Log Manager");
            Console.WriteLine("1. Add Call Log");
            Console.WriteLine("2. Search by Keyword");
            Console.WriteLine("3. Filter by Time");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.AddCallLog();
                    break;

                case 2:
                    manager.SearchByKeyword();
                    break;

                case 3:
                    manager.FilterByTime();
                    break;

                case 4:
                    Console.WriteLine(" Exiting application...");
                    break;

                default:
                    Console.WriteLine(" Invalid choice. Try again.");
                    break;
            }
        }
        while (choice != 4);
    }
}
