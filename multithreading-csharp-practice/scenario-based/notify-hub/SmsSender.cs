using System;
using System.Threading.Tasks;

public class SmsSender : INotificationSender
{
    public async Task SendAsync(Notification notification)
    {
        await Task.Delay(800);
        Console.WriteLine("SMS sent to " + notification.Recipient);
    }
}
