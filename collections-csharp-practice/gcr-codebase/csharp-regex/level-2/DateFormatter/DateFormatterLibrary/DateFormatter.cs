using System;
using System.Globalization;

public class DateFormatter
{
    public string FormatDate(string inputDate)
    {
        DateTime date = DateTime.ParseExact(
            inputDate,
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture
        );

        return date.ToString("dd-MM-yyyy");
    }
}