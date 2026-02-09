using System;
using Microsoft.Data.SqlClient;

public class VisitService : IVisitService
{
    /* =====================================================
       UC-4.1 : Record Patient Visit
       Actor  : Doctor
       Flow   : Insert into Visits + Update Appointment
       ===================================================== */
    public void RecordPatientVisit()
    {
        Console.Write("Appointment ID: ");
        int appointmentId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Diagnosis: ");
        string diagnosis = Console.ReadLine();

        Console.Write("Notes: ");
        string notes = Console.ReadLine();

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();
        SqlTransaction tx = con.BeginTransaction();

        try
        {
            string visitQuery =
                "INSERT INTO Visits(appointment_id, diagnosis, notes) " +
                "VALUES(@aid, @d, @n)";

            SqlCommand visitCmd = new SqlCommand(visitQuery, con, tx);
            visitCmd.Parameters.AddWithValue("@aid", appointmentId);
            visitCmd.Parameters.AddWithValue("@d", diagnosis);
            visitCmd.Parameters.AddWithValue("@n", notes);
            visitCmd.ExecuteNonQuery();

            string updateAppointment =
                "UPDATE Appointments SET status='COMPLETED' WHERE appointment_id=@id";

            SqlCommand updateCmd = new SqlCommand(updateAppointment, con, tx);
            updateCmd.Parameters.AddWithValue("@id", appointmentId);
            updateCmd.ExecuteNonQuery();

            tx.Commit();
            Console.WriteLine("✅ Visit recorded successfully");
        }
        catch (Exception ex)
        {
            tx.Rollback();
            Console.WriteLine("❌ Error: " + ex.Message);
        }
    }

    /* =====================================================
       UC-4.2 : View Patient Medical History
       Actor  : Doctor
       Flow   : Join Visits + Prescriptions + Appointments
       ===================================================== */
    public void ViewMedicalHistory()
    {
        Console.Write("Patient ID: ");
        int patientId = Convert.ToInt32(Console.ReadLine());

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string query =
        @"SELECT v.visit_date, v.diagnosis, pr.medicine_name,
                 pr.dosage, pr.duration
          FROM Visits v
          JOIN Appointments a ON v.appointment_id = a.appointment_id
          LEFT JOIN Prescriptions pr ON v.visit_id = pr.visit_id
          WHERE a.patient_id = @pid
          ORDER BY v.visit_date DESC";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@pid", patientId);

        SqlDataReader rd = cmd.ExecuteReader();

        Console.WriteLine("\n--- Medical History ---");
        while (rd.Read())
        {
            Console.WriteLine(
                $"{rd["visit_date"]} | {rd["diagnosis"]} | " +
                $"{rd["medicine_name"]} | {rd["dosage"]} | {rd["duration"]}");
        }
    }

    /* =====================================================
       UC-4.3 : Add Prescription Details
       Actor  : Doctor
       Flow   : Batch Insert Prescriptions
       ===================================================== */
    public void AddPrescriptionDetails()
    {
        Console.Write("Visit ID: ");
        int visitId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Number of medicines: ");
        int count = Convert.ToInt32(Console.ReadLine());

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string query =
            "INSERT INTO Prescriptions(visit_id, medicine_name, dosage, duration) " +
            "VALUES(@vid, @m, @d, @du)";

        SqlCommand cmd = new SqlCommand(query, con);

        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"\nMedicine {i}:");
            Console.Write("Name: ");
            string med = Console.ReadLine();
            Console.Write("Dosage: ");
            string dosage = Console.ReadLine();
            Console.Write("Duration: ");
            string duration = Console.ReadLine();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@vid", visitId);
            cmd.Parameters.AddWithValue("@m", med);
            cmd.Parameters.AddWithValue("@d", dosage);
            cmd.Parameters.AddWithValue("@du", duration);

            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("✅ Prescriptions added");
    }
}
