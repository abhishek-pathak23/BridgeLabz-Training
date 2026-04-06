using System;
using Microsoft.Data.SqlClient;

public class AppointmentService : IAppointmentService
{
    /* ======================================================
       UC-3.1 : BOOK NEW APPOINTMENT
       Actor   : Receptionist
       Purpose : Book appointment after checking availability
       ====================================================== */
    public void BookAppointment()
    {
        // Take patient id
        Console.Write("Patient ID: ");
        int patientId = int.Parse(Console.ReadLine());

        // Take doctor id
        Console.Write("Doctor ID: ");
        int doctorId = int.Parse(Console.ReadLine());

        // Take appointment date
        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        // Take appointment time
        Console.Write("Time (HH:mm): ");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine());

        using SqlConnection conn = DbUtil.GetConnection();
        conn.Open();

        // Step 1: Check doctor availability for selected date & time
        string checkQuery =
            "SELECT COUNT(*) FROM appointments " +
            "WHERE doctor_id=@doc AND appointment_date=@date " +
            "AND appointment_time=@time AND status='SCHEDULED'";

        using SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
        checkCmd.Parameters.AddWithValue("@doc", doctorId);
        checkCmd.Parameters.AddWithValue("@date", date);
        checkCmd.Parameters.AddWithValue("@time", time);

        int count = (int)checkCmd.ExecuteScalar();

        // If already booked → stop
        if (count > 0)
        {
            Console.WriteLine("Doctor not available for this slot.");
            return;
        }

        // Step 2: Insert appointment
        string insertQuery =
            "INSERT INTO appointments " +
            "(patient_id, doctor_id, appointment_date, appointment_time, status) " +
            "VALUES(@pid, @did, @date, @time, 'SCHEDULED')";

        using SqlCommand cmd = new SqlCommand(insertQuery, conn);
        cmd.Parameters.AddWithValue("@pid", patientId);
        cmd.Parameters.AddWithValue("@did", doctorId);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.Parameters.AddWithValue("@time", time);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Appointment booked successfully.");
    }

    /* ======================================================
       UC-3.2 : CHECK DOCTOR AVAILABILITY
       Actor   : Receptionist
       Purpose : Show booked slots count for a doctor
       ====================================================== */
    public void CheckDoctorAvailability()
    {
        // Take doctor id
        Console.Write("Doctor ID: ");
        int doctorId = int.Parse(Console.ReadLine());

        // Take date
        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        using SqlConnection conn = DbUtil.GetConnection();
        conn.Open();

        // Group appointments slot-wise
        string query =
            "SELECT appointment_time, COUNT(*) AS bookings " +
            "FROM appointments " +
            "WHERE doctor_id=@doc AND appointment_date=@date " +
            "GROUP BY appointment_time";

        using SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@doc", doctorId);
        cmd.Parameters.AddWithValue("@date", date);

        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nTime Slot | Bookings");
        while (reader.Read())
        {
            Console.WriteLine($"{reader["appointment_time"]} | {reader["bookings"]}");
        }
    }

    /* ======================================================
       UC-3.3 : CANCEL APPOINTMENT
       Actor   : Receptionist / Patient
       Purpose : Cancel appointment + log audit
       ====================================================== */
    public void CancelAppointment()
    {
        // Take appointment id
        Console.Write("Appointment ID: ");
        int appointmentId = int.Parse(Console.ReadLine());

        using SqlConnection conn = DbUtil.GetConnection();
        conn.Open();

        // Start transaction
        SqlTransaction tx = conn.BeginTransaction();

        try
        {
            // Step 1: Update appointment status
            string cancelQuery =
                "UPDATE appointments SET status='CANCELLED' " +
                "WHERE appointment_id=@id";

            using SqlCommand cmd = new SqlCommand(cancelQuery, conn, tx);
            cmd.Parameters.AddWithValue("@id", appointmentId);
            cmd.ExecuteNonQuery();

            // Step 2: Insert audit log
            string auditQuery =
                "INSERT INTO appointment_audit " +
                "(appointment_id, action_date, action) " +
                "VALUES(@id, GETDATE(), 'CANCELLED')";

            using SqlCommand auditCmd = new SqlCommand(auditQuery, conn, tx);
            auditCmd.Parameters.AddWithValue("@id", appointmentId);
            auditCmd.ExecuteNonQuery();

            // Commit if success
            tx.Commit();
            Console.WriteLine("Appointment cancelled successfully.");
        }
        catch
        {
            // Rollback on error
            tx.Rollback();
            Console.WriteLine("Cancellation failed.");
        }
    }

    /* ======================================================
       UC-3.4 : RESCHEDULE APPOINTMENT
       Actor   : Receptionist
       Purpose : Change appointment date & time
       ====================================================== */
    public void RescheduleAppointment()
    {
        // Take appointment id
        Console.Write("Appointment ID: ");
        int appointmentId = int.Parse(Console.ReadLine());

        // Take new date
        Console.Write("New Date (yyyy-mm-dd): ");
        DateTime newDate = DateTime.Parse(Console.ReadLine());

        // Take new time
        Console.Write("New Time (HH:mm): ");
        TimeSpan newTime = TimeSpan.Parse(Console.ReadLine());

        using SqlConnection conn = DbUtil.GetConnection();
        conn.Open();

        SqlTransaction tx = conn.BeginTransaction();

        try
        {
            string updateQuery =
                "UPDATE appointments SET " +
                "appointment_date=@date, appointment_time=@time " +
                "WHERE appointment_id=@id";

            using SqlCommand cmd = new SqlCommand(updateQuery, conn, tx);
            cmd.Parameters.AddWithValue("@date", newDate);
            cmd.Parameters.AddWithValue("@time", newTime);
            cmd.Parameters.AddWithValue("@id", appointmentId);

            cmd.ExecuteNonQuery();
            tx.Commit();

            Console.WriteLine("Appointment rescheduled successfully.");
        }
        catch
        {
            tx.Rollback();
            Console.WriteLine("Reschedule failed.");
        }
    }

    /* ======================================================
       UC-3.5 : VIEW DAILY APPOINTMENT SCHEDULE
       Actor   : Doctor / Receptionist
       Purpose : Show appointments for a date
       ====================================================== */
    public void ViewDailySchedule()
    {
        // Take date
        Console.Write("Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        using SqlConnection conn = DbUtil.GetConnection();
        conn.Open();

        // Join appointments, patients, doctors
        string query =
            "SELECT a.appointment_time, p.name AS Patient, d.name AS Doctor " +
            "FROM appointments a " +
            "JOIN patients p ON a.patient_id = p.patient_id " +
            "JOIN doctors d ON a.doctor_id = d.doctor_id " +
            "WHERE a.appointment_date=@date AND a.status='SCHEDULED' " +
            "ORDER BY a.appointment_time";

        using SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@date", date);

        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["appointment_time"]} | {reader["Patient"]} | {reader["Doctor"]}");
        }
    }
}
