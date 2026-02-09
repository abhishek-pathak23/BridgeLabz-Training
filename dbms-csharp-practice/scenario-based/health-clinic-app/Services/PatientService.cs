using System;
using Microsoft.Data.SqlClient;

public class PatientService : IPatientService
{
    // UC-1.1 Register New Patient
    public void RegisterPatient()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("DOB (yyyy-mm-dd): ");
        DateTime dob = DateTime.Parse(Console.ReadLine());

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Blood Group: ");
        string bg = Console.ReadLine();

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string check = "SELECT COUNT(*) FROM Patients WHERE phone=@phone";
        SqlCommand checkCmd = new SqlCommand(check, con);
        checkCmd.Parameters.AddWithValue("@phone", phone);

        int exists = (int)checkCmd.ExecuteScalar();
        if (exists > 0)
        {
            Console.WriteLine("❌ Patient already exists");
            return;
        }

        string insert =
            "INSERT INTO Patients(name,dob,phone,address,blood_group) " +
            "VALUES(@n,@d,@p,@a,@b)";

        SqlCommand cmd = new SqlCommand(insert, con);
        cmd.Parameters.AddWithValue("@n", name);
        cmd.Parameters.AddWithValue("@d", dob);
        cmd.Parameters.AddWithValue("@p", phone);
        cmd.Parameters.AddWithValue("@a", address);
        cmd.Parameters.AddWithValue("@b", bg);

        cmd.ExecuteNonQuery();
        Console.WriteLine("✅ Patient registered successfully");
    }

    // UC-1.2 Update Patient Information
    public void UpdatePatient()
    {
        Console.Write("Patient ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("New Address: ");
        string address = Console.ReadLine();

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        SqlCommand cmd = new SqlCommand(
            "UPDATE Patients SET address=@a WHERE patient_id=@id", con);
        cmd.Parameters.AddWithValue("@a", address);
        cmd.Parameters.AddWithValue("@id", id);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine(rows > 0 ? "✅ Patient updated" : "❌ Patient not found");
    }

    // UC-1.3 Search Patient Records
    public void SearchPatient()
    {
        Console.Write("Enter name or phone: ");
        string input = Console.ReadLine();

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM Patients WHERE name LIKE @v OR phone LIKE @v", con);
        cmd.Parameters.AddWithValue("@v", "%" + input + "%");

        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            Console.WriteLine(
                $"{rd["patient_id"]} | {rd["name"]} | {rd["phone"]}");
        }
    }

    // UC-1.4 View Patient Visit History ✅ FIXED
    public void ViewPatientVisitHistory()
    {
        Console.Write("Patient ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string query =
        @"SELECT d.name AS Doctor, v.diagnosis, v.visit_date
          FROM Visits v
          JOIN Appointments a ON v.appointment_id = a.appointment_id
          JOIN Doctors d ON a.doctor_id = d.doctor_id
          WHERE a.patient_id = @id
          ORDER BY v.visit_date";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            Console.WriteLine(
                $"{rd["Doctor"]} | {rd["diagnosis"]} | {rd["visit_date"]}");
        }
    }
}
