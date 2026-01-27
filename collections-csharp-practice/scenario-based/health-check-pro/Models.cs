public class APIMethod
{
    private string controllerName;
    private string methodName;
    private bool isPublicAPI;
    private string publicAPIDescription;
    private bool requiresAuth;
    private string authRole;

    public string ControllerName { get => controllerName; set => controllerName = value; }
    public string MethodName { get => methodName; set => methodName = value; }
    public bool IsPublicAPI { get => isPublicAPI; set => isPublicAPI = value; }
    public string PublicAPIDescription { get => publicAPIDescription; set => publicAPIDescription = value; }
    public bool RequiresAuth { get => requiresAuth; set => requiresAuth = value; }
    public string AuthRole { get => authRole; set => authRole = value; }

    public override string ToString()
    {
        string info = $"Method: {methodName}";
        if (isPublicAPI) info += $", [PublicAPI] Description: {publicAPIDescription}";
        if (requiresAuth) info += $", [RequiresAuth] Role: {authRole}";
        if (!isPublicAPI && !requiresAuth) info += " [MISSING ANNOTATION]";
        return info;
    }
}
