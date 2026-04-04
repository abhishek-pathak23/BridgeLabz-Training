using System;

class TimeZoneDisplay
{
    // Method displays current time in needed time zones
    static void ShowTimeZones()
    {
        DateTimeOffset utcTime = DateTimeOffset.UtcNow;

        TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        Console.WriteLine("GMT Time: " + utcTime);                                              // All three timezones mentioned
        Console.WriteLine("IST Time: " + TimeZoneInfo.ConvertTime(utcTime, istZone));
        Console.WriteLine("PST Time: " + TimeZoneInfo.ConvertTime(utcTime, pstZone));
    }

    static void Main()
    {
        ShowTimeZones();               // calling the method
    }
}
