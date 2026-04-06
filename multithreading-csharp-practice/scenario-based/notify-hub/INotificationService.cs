using System.Threading.Tasks;

public interface INotificationSender
{
    Task SendAsync(Notification notification);
}
