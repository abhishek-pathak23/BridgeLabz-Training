using System;

[AttributeUsage(AttributeTargets.Method)]
public class AuditTrailAttribute : Attribute
{
    public string Description { get; }
    public AuditTrailAttribute(string description = "")
    {
        Description = description;
    }
}
