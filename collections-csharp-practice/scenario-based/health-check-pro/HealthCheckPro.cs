using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

public class HealthCheckPro : IScanner
{
    private List<APIMethod> apiMethods = new List<APIMethod>();

    // Scan controllers using reflection
    public List<APIMethod> ScanControllers()
    {
        apiMethods.Clear(); // Clear previous scan

        var assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            if (!type.Name.EndsWith("Controller")) continue;

            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                var apiMethod = new APIMethod
                {
                    ControllerName = type.Name,
                    MethodName = method.Name,
                    IsPublicAPI = method.GetCustomAttribute<PublicAPIAttribute>() != null,
                    PublicAPIDescription = method.GetCustomAttribute<PublicAPIAttribute>()?.Description ?? "",
                    RequiresAuth = method.GetCustomAttribute<RequiresAuthAttribute>() != null,
                    AuthRole = method.GetCustomAttribute<RequiresAuthAttribute>()?.Role ?? ""
                };

                apiMethods.Add(apiMethod);
            }
        }

        Console.WriteLine("\n[Scan Complete] Found " + apiMethods.Count + " API methods.\n");
        return apiMethods;
    }

    // Generate documentation to file
    public void GenerateDocumentation(string filePath)
    {
        if (apiMethods.Count == 0)
        {
            Console.WriteLine("No API methods scanned. Please scan controllers first.\n");
            return;
        }

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var api in apiMethods)
            {
                writer.WriteLine($"Controller: {api.ControllerName} -> {api}");
                Console.WriteLine($"Controller: {api.ControllerName} -> {api}");
            }
        }
        Console.WriteLine($"\nAPI documentation generated at {filePath}\n");
    }

    // Show only missing annotations
    public void ShowMissingAnnotations()
    {
        if (apiMethods.Count == 0)
        {
            Console.WriteLine("No API methods scanned. Please scan controllers first.\n");
            return;
        }

        Console.WriteLine("\n--- Methods Missing Annotations ---");
        foreach (var api in apiMethods)
        {
            if (!api.IsPublicAPI && !api.RequiresAuth)
            {
                Console.WriteLine($"Controller: {api.ControllerName} -> {api.MethodName}");
            }
        }
        Console.WriteLine();
    }
}
