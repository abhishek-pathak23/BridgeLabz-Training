using System;
using System.IO;
using System.Collections.Generic;


class Student
{
public int ID;
public string Name;
public int Age;
public int Marks;


public override string ToString() => $"ID={ID}, Name={Name}, Age={Age}, Marks={Marks}";
}


class Problem9_CSVToObjects
{
static void Main()
{
string filePath = "students.csv";


if (!File.Exists(filePath))
{
Console.WriteLine("File not found: " + filePath);
return;
}


var lines = File.ReadAllLines(filePath);
List<Student> students = new List<Student>();


foreach (var line in lines.Skip(1))
{
var cols = line.Split(',');
students.Add(new Student
{
ID = int.Parse(cols[0]),
Name = cols[1],
Age = int.Parse(cols[2]),
Marks = int.Parse(cols[3])
});
}


Console.WriteLine("Students:");
foreach (var s in students) Console.WriteLine(s);
}
}