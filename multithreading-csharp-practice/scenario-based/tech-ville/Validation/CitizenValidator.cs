using System;
using System.Text.RegularExpressions;

public static class CitizenValidator
{
    // Email
    private static readonly Regex emailRegex =
        new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    // Indian phone (simple format)
    private static readonly Regex phoneRegex =
        new Regex(@"^(\+91[- ]?)?[6-9]\d{9}$", RegexOptions.Compiled);

    // Citizen ID: TC-2024-00001
    private static readonly Regex citizenIdRegex =
        new Regex(@"^TC-\d{4}-\d{5}$", RegexOptions.Compiled);

    // Strong password
    private static readonly Regex passwordRegex =
        new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$",
        RegexOptions.Compiled);

    // PIN code (6 digits)
    private static readonly Regex pinRegex =
        new Regex(@"\b\d{6}\b", RegexOptions.Compiled);

    public static bool ValidateEmail(string email)
        => emailRegex.IsMatch(email);

    public static bool ValidatePhone(string phone)
        => phoneRegex.IsMatch(phone);

    public static bool ValidateCitizenId(string id)
        => citizenIdRegex.IsMatch(id);

    public static bool ValidatePassword(string password)
        => passwordRegex.IsMatch(password);

    public static string ExtractPinCode(string address)
    {
        var match = pinRegex.Match(address);
        return match.Success ? match.Value : "No PIN found";
    }
}
