using System;
using System.Data.SqlClient;
using System.IO;

class Problem13_DBToCSV
{
    static void Main()
    {
        string connectionString = "Server=.;Database=YourDB;Trusted_Connection=True;";
        string outputFile = "employee_report.csv";

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT EmployeeID, Name, Department, Salary FROM Employees", conn);
            var reader = cmd.ExecuteReader();

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("EmployeeID,Name,Department,Salary");
                while (reader.Read())
                {
                    writer.WriteLine($"{reader["EmployeeID"]},{reader["Name"]},{reader["Department"]},{reader["Salary"]}");
                }
            }
        }

        Console.WriteLine("CSV report generated: " + outputFile);
    }
}