using System;

[AttributeUsage(AttributeTargets.Method)]
public class PublicAPIAttribute : Attribute
{
    public string Description { get; }
    public PublicAPIAttribute(string description = "")
    {
        Description = description;
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class RequiresAuthAttribute : Attribute
{
    public string Role { get; }
    public RequiresAuthAttribute(string role = "User")
    {
        Role = role;
    }
}
