using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

public class NotificationManager
{
    private List<Notification> notifications = new List<Notification>();
    private string logFile = "notifyhub_log.txt";

    public void AddNotification(Notification notification)
    {
        var context = new ValidationContext(notification);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(notification, context, results, true);

        if (!isValid)
        {
            notification.Status = NotificationStatus.Rejected;
            Console.WriteLine("Rejected Notification:");
            foreach (var error in results)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            WriteLog("Rejected: " + notification.NotificationId);
            return;
        }

        notifications.Add(notification);
        Console.WriteLine("Notification Added Successfully");
    }

    public async Task ProcessNotificationsAsync()
    {
        if (notifications.Count == 0)
        {
            Console.WriteLine("No notifications to process.");
            return;
        }

        // Manual Sorting (High Priority First)
        for (int i = 0; i < notifications.Count - 1; i++)
        {
            for (int j = i + 1; j < notifications.Count; j++)
            {
                if ((int)notifications[i].Priority < (int)notifications[j].Priority)
                {
                    Notification temp = notifications[i];
                    notifications[i] = notifications[j];
                    notifications[j] = temp;
                }
            }
        }

        List<Task> taskList = new List<Task>();

        foreach (Notification notification in notifications)
        {
            taskList.Add(ProcessSingleNotification(notification));
        }

        await Task.WhenAll(taskList);

        Console.WriteLine("All notifications processed.\n");
    }

    private async Task ProcessSingleNotification(Notification notification)
    {
        try
        {
            notification.Status = NotificationStatus.Processing;

            INotificationSender sender = null;

            if (notification.Type == "Email")
                sender = new EmailSender();
            else if (notification.Type == "SMS")
                sender = new SmsSender();
            else
                throw new Exception("Invalid Notification Type");

            await sender.SendAsync(notification);

            notification.Status = NotificationStatus.Sent;
            WriteLog("Sent: " + notification.NotificationId);
        }
        catch (Exception ex)
        {
            notification.Status = NotificationStatus.Failed;
            WriteLog("Failed: " + notification.NotificationId + " | " + ex.Message);
        }
    }

    private void WriteLog(string message)
    {
        File.AppendAllText(logFile,
            DateTime.Now + " - " + message + Environment.NewLine);
    }

    public void ViewAll()
    {
        if (notifications.Count == 0)
        {
            Console.WriteLine("No notifications found.");
            return;
        }

        foreach (Notification n in notifications)
        {
            Console.WriteLine("ID: " + n.NotificationId +
                              " | Type: " + n.Type +
                              " | Priority: " + n.Priority +
                              " | Status: " + n.Status);
        }
    }
}
