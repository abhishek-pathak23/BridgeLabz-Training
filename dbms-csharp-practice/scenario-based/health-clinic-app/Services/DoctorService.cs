using System;
using Microsoft.Data.SqlClient;

public class DoctorService : IDoctorService
{
    /* =====================================================
       UC-2.1 : Add Doctor Profile
       ===================================================== */
    public void AddDoctorProfile()
    {
        Console.Write("Doctor Name: ");
        string name = Console.ReadLine();

        Console.Write("Contact: ");
        string contact = Console.ReadLine();

        Console.Write("Consultation Fee: ");
        decimal fee = decimal.Parse(Console.ReadLine());

        Console.Write("Specialty ID: ");
        int specialtyId = int.Parse(Console.ReadLine());

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string sql =
            "INSERT INTO Doctors(name,contact,consultation_fee,specialty_id) " +
            "VALUES(@n,@c,@f,@s)";

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@n", name);
        cmd.Parameters.AddWithValue("@c", contact);
        cmd.Parameters.AddWithValue("@f", fee);
        cmd.Parameters.AddWithValue("@s", specialtyId);

        cmd.ExecuteNonQuery();
        Console.WriteLine("✅ Doctor profile added");
    }

    /* =====================================================
       UC-2.2 : Assign / Update Doctor Specialty
       (Uses TRANSACTION)
       ===================================================== */
    public void UpdateDoctorSpecialty()
    {
        using SqlConnection con = DbUtil.GetConnection();
        con.Open();
        SqlTransaction tx = con.BeginTransaction();

        try
        {
            Console.WriteLine("\nAvailable Specialties:");
            SqlCommand spCmd = new SqlCommand(
                "SELECT specialty_id,specialty_name FROM Specialties",
                con, tx);

            SqlDataReader spReader = spCmd.ExecuteReader();
            while (spReader.Read())
            {
                Console.WriteLine($"{spReader["specialty_id"]} - {spReader["specialty_name"]}");
            }
            spReader.Close();

            Console.Write("Doctor ID: ");
            int docId = int.Parse(Console.ReadLine());

            Console.Write("New Specialty ID: ");
            int newSpId = int.Parse(Console.ReadLine());

            SqlCommand updateCmd = new SqlCommand(
                "UPDATE Doctors SET specialty_id=@s WHERE doctor_id=@d",
                con, tx);

            updateCmd.Parameters.AddWithValue("@s", newSpId);
            updateCmd.Parameters.AddWithValue("@d", docId);

            updateCmd.ExecuteNonQuery();

            tx.Commit();
            Console.WriteLine("✅ Doctor specialty updated");
        }
        catch
        {
            tx.Rollback();
            Console.WriteLine("❌ Update failed, transaction rolled back");
        }
    }

    /* =====================================================
       UC-2.3 : View Doctors by Specialty
       (JOIN query)
       ===================================================== */
    public void ViewDoctorsBySpecialty()
    {
        Console.Write("Enter Specialty Name: ");
        string specialty = Console.ReadLine();

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string sql =
        @"SELECT d.name, d.contact, d.consultation_fee
          FROM Doctors d
          JOIN Specialties s ON d.specialty_id = s.specialty_id
          WHERE s.specialty_name = @sp
          AND d.is_active = 1";

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@sp", specialty);

        SqlDataReader rd = cmd.ExecuteReader();
        Console.WriteLine("\nDoctors Available:");
        while (rd.Read())
        {
            Console.WriteLine(
                $"{rd["name"]} | {rd["contact"]} | Fee: {rd["consultation_fee"]}");
        }
    }

    /* =====================================================
       UC-2.4 : Deactivate Doctor Profile
       (Soft delete + nested SELECT)
       ===================================================== */
    public void DeactivateDoctor()
    {
        Console.Write("Doctor ID to deactivate: ");
        int docId = int.Parse(Console.ReadLine());

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        // Check future appointments
        string checkSql =
        @"SELECT COUNT(*) FROM Appointments
          WHERE doctor_id=@id
          AND appointment_date >= CAST(GETDATE() AS DATE)
          AND status='SCHEDULED'";

        SqlCommand checkCmd = new SqlCommand(checkSql, con);
        checkCmd.Parameters.AddWithValue("@id", docId);

        int count = (int)checkCmd.ExecuteScalar();

        if (count > 0)
        {
            Console.WriteLine("❌ Cannot deactivate. Future appointments exist.");
            return;
        }

        // Soft delete
        SqlCommand deactivateCmd = new SqlCommand(
            "UPDATE Doctors SET is_active=0 WHERE doctor_id=@id", con);
        deactivateCmd.Parameters.AddWithValue("@id", docId);

        deactivateCmd.ExecuteNonQuery();
        Console.WriteLine("✅ Doctor deactivated (soft delete)");
    }
}
