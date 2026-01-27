using System;

public class EventLog
{
    private string className;
    private string methodName;
    private string description;
    private DateTime timestamp;

    public string ClassName { get => className; set => className = value; }
    public string MethodName { get => methodName; set => methodName = value; }
    public string Description { get => description; set => description = value; }
    public DateTime Timestamp { get => timestamp; set => timestamp = value; }

    public override string ToString()
    {
        return $"{{\"Class\":\"{className}\",\"Method\":\"{methodName}\",\"Description\":\"{description}\",\"Timestamp\":\"{timestamp:O}\"}}";
    }
}
