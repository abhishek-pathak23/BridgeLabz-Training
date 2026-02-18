using System;
using System.Collections.Generic;
using System.IO;

public class ConfigManager
{
    private string configPath = "config.txt";

    public Dictionary<string, string> ReadConfig()
    {
        var config = new Dictionary<string, string>();

        if (!File.Exists(configPath))
            return config;

        foreach (var line in File.ReadAllLines(configPath))
        {
            var parts = line.Split('=');
            if (parts.Length == 2)
                config[parts[0]] = parts[1];
        }

        return config;
    }
}
