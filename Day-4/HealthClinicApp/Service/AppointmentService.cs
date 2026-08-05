using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly DBConnectionUtility _dbUtility;

        public AppointmentService(DBConnectionUtility dbUtility)
        {
            _dbUtility = dbUtility;
        }

        private SqlConnection GetConnection() => _dbUtility.CreateConnection();

        // Book appointment using stored procedure sp_BookAppointment
        public int BookAppointment(int patientId, int doctorId, DateTime date)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_BookAppointment", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@PatientID", patientId);
            cmd.Parameters.AddWithValue("@DoctorID", doctorId);
            cmd.Parameters.AddWithValue("@AppointmentDate", date);

            var outParam = new SqlParameter("@NewAppointmentID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outParam);

            conn.Open();
            cmd.ExecuteNonQuery();

            return (int)outParam.Value;
        }

        // Get all appointments with patient and doctor names
        public List<Appointment> GetAllAppointments()
        {
            var list = new List<Appointment>();
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_GetAllAppointments", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Appointment
                {
                    AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                    PatientID = Convert.ToInt32(reader["PatientID"]),
                    PatientName = reader["PatientName"].ToString() ?? "",
                    DoctorID = Convert.ToInt32(reader["DoctorID"]),
                    DoctorName = reader["DoctorName"].ToString() ?? "",
                    Specialization = reader["Specialization"].ToString() ?? "",
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"].ToString() ?? ""
                });
            }
            return list;
        }

        // Update appointment status (triggers auto-billing if set to 'Completed')
        public bool UpdateAppointmentStatus(int appointmentId, string newStatus)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_UpdateAppointmentStatus", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
            cmd.Parameters.AddWithValue("@NewStatus", newStatus);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }

        // Cancel an appointment
        public bool CancelAppointment(int appointmentId)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_CancelAppointment", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }

        // Get appointments filtered by Doctor ID (for Doctor role menu)
        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            var list = new List<Appointment>();
            using var conn = GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT a.AppointmentID, a.PatientID,
                       (p.FirstName + ' ' + ISNULL(p.LastName, '')) AS PatientName,
                       a.DoctorID, d.DoctorName, d.Specialization,
                       a.AppointmentDate, a.Status
                FROM Appointments a
                INNER JOIN Patients p ON a.PatientID = p.PatientID
                INNER JOIN Doctors d ON a.DoctorID = d.DoctorID
                WHERE a.DoctorID = @DoctorID
                ORDER BY a.AppointmentDate DESC", conn);

            cmd.Parameters.AddWithValue("@DoctorID", doctorId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Appointment
                {
                    AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                    PatientID = Convert.ToInt32(reader["PatientID"]),
                    PatientName = reader["PatientName"].ToString() ?? "",
                    DoctorID = Convert.ToInt32(reader["DoctorID"]),
                    DoctorName = reader["DoctorName"].ToString() ?? "",
                    Specialization = reader["Specialization"].ToString() ?? "",
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"].ToString() ?? ""
                });
            }
            return list;
        }

        // Get appointments filtered by Patient ID (for Patient role menu)
        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            var list = new List<Appointment>();
            using var conn = GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT a.AppointmentID, a.PatientID,
                       (p.FirstName + ' ' + ISNULL(p.LastName, '')) AS PatientName,
                       a.DoctorID, d.DoctorName, d.Specialization,
                       a.AppointmentDate, a.Status
                FROM Appointments a
                INNER JOIN Patients p ON a.PatientID = p.PatientID
                INNER JOIN Doctors d ON a.DoctorID = d.DoctorID
                WHERE a.PatientID = @PatientID
                ORDER BY a.AppointmentDate DESC", conn);

            cmd.Parameters.AddWithValue("@PatientID", patientId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Appointment
                {
                    AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                    PatientID = Convert.ToInt32(reader["PatientID"]),
                    PatientName = reader["PatientName"].ToString() ?? "",
                    DoctorID = Convert.ToInt32(reader["DoctorID"]),
                    DoctorName = reader["DoctorName"].ToString() ?? "",
                    Specialization = reader["Specialization"].ToString() ?? "",
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"].ToString() ?? ""
                });
            }
            return list;
        }
    }
}
