using System;
using System.ComponentModel.DataAnnotations;

public enum PriorityLevel
{
    Low = 1,
    Medium = 2,
    High = 3
}

public enum NotificationStatus
{
    Pending,
    Processing,
    Sent,
    Failed,
    Rejected
}

public class Notification
{
    [Required(ErrorMessage = "Notification ID is required")]
    public string NotificationId { get; set; }

    [Required(ErrorMessage = "Recipient is required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|in|org|edu)$",
        ErrorMessage = "Invalid Email Format")]
    public string Recipient { get; set; }

    [Required]
    public string Message { get; set; }

    [Range(1, 3)]
    public PriorityLevel Priority { get; set; }

    public string Type { get; set; }   // Email or SMS

    public NotificationStatus Status { get; set; } = NotificationStatus.Pending;

    public DateTime CreatedTime { get; set; } = DateTime.Now;
}
