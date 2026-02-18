using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        NotificationManager manager = new NotificationManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== NotifyHub Menu =====");
            Console.WriteLine("1. Add Notification");
            Console.WriteLine("2. Process Notifications");
            Console.WriteLine("3. View Notifications");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Notification notification = new Notification();

                    Console.Write("Enter ID: ");
                    notification.NotificationId = Console.ReadLine();

                    Console.Write("Enter Email: ");
                    notification.Recipient = Console.ReadLine();

                    Console.Write("Enter Message: ");
                    notification.Message = Console.ReadLine();

                    Console.Write("Enter Priority (1=Low,2=Medium,3=High): ");
                    notification.Priority =
                        (PriorityLevel)Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Type (Email/SMS): ");
                    notification.Type = Console.ReadLine();

                    manager.AddNotification(notification);
                    break;

                case 2:
                    await manager.ProcessNotificationsAsync();
                    break;

                case 3:
                    manager.ViewAll();
                    break;

                case 4:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
