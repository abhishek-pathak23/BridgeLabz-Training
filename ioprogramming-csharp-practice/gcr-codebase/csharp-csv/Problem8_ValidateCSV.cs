using System;
using System.IO;
using System.Text.RegularExpressions;


class Problem8_ValidateCSV
{
static void Main()
{
string filePath = "contacts.csv";


if (!File.Exists(filePath))
{
Console.WriteLine("File not found: " + filePath);
return;
}


var lines = File.ReadAllLines(filePath);
var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");


Console.WriteLine("Invalid rows:");
foreach (var line in lines.Skip(1))
{
var cols = line.Split(',');
string email = cols[2];
string phone = cols[3];


bool validEmail = emailRegex.IsMatch(email);
bool validPhone = phone.Length == 10 && long.TryParse(phone, out _);


if (!validEmail || !validPhone)
{
Console.WriteLine(line + " <-- Invalid data");
}
}
}
}