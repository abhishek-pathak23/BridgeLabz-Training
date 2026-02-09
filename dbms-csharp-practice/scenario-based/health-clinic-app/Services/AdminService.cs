using System;
using Microsoft.Data.SqlClient;

public class AdminService : IAdminService
{
    // ================= UC-6.1 Add Specialty =================
    public void AddSpecialty()
    {
        Console.Write("Enter Specialty Name: ");
        string specialty = Console.ReadLine()!;

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string query = "INSERT INTO Specialties(name) VALUES(@name)";
        using SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@name", specialty);

        cmd.ExecuteNonQuery();
        Console.WriteLine("✅ Specialty added");
    }

    // ================= UC-6.1 View Specialties =================
    public void ViewSpecialties()
    {
        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string query = "SELECT specialty_id, name FROM Specialties";
        using SqlCommand cmd = new SqlCommand(query, con);
        using SqlDataReader rd = cmd.ExecuteReader();

        while (rd.Read())
        {
            Console.WriteLine($"{rd["specialty_id"]} - {rd["name"]}");
        }
    }

    // ================= UC-6.1 Delete Specialty =================
    public void DeleteSpecialty()
    {
        Console.Write("Enter Specialty ID to delete: ");
        int sid = int.Parse(Console.ReadLine()!);

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        // Check foreign key usage
        string checkQuery =
            @"SELECT COUNT(*) 
              FROM Doctors 
              WHERE specialty_id = @sid";

        using SqlCommand checkCmd = new SqlCommand(checkQuery, con);
        checkCmd.Parameters.AddWithValue("@sid", sid);

        int count = (int)checkCmd.ExecuteScalar();

        if (count > 0)
        {
            Console.WriteLine("❌ Cannot delete. Doctors are assigned to this specialty.");
            return;
        }

        string deleteQuery = "DELETE FROM Specialties WHERE specialty_id=@sid";
        using SqlCommand delCmd = new SqlCommand(deleteQuery, con);
        delCmd.Parameters.AddWithValue("@sid", sid);

        delCmd.ExecuteNonQuery();
        Console.WriteLine("✅ Specialty deleted");
    }

    // ================= UC-6.3 View Audit Logs =================
    public void ViewAuditLogs()
    {
        Console.Write("Filter by table name (or press Enter): ");
        string table = Console.ReadLine();

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string query =
            @"SELECT user_name, table_name, action, action_time
              FROM audit_log
              WHERE (@table IS NULL OR table_name = @table)
              ORDER BY action_time DESC";

        using SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@table",
            string.IsNullOrEmpty(table) ? DBNull.Value : table);

        using SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            Console.WriteLine(
                $"{rd["user_name"]} | {rd["table_name"]} | {rd["action"]} | {rd["action_time"]}"
            );
        }
    }
}
