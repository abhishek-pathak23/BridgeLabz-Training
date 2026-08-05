using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Service
{
    public class DoctorService
    {
        private readonly string _connectionString;

        public DoctorService(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        // Fetch all doctors from database
        public List<Doctor> GetAllDoctors()
        {
            var list = new List<Doctor>();
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_GetAllDoctors", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Doctor
                {
                    DoctorID = Convert.ToInt32(reader["DoctorID"]),
                    DoctorName = reader["DoctorName"].ToString() ?? "",
                    Specialization = reader["Specialization"].ToString() ?? "",
                    Phone = reader["Phone"].ToString() ?? "",
                    ExperienceYears = Convert.ToInt32(reader["ExperienceYears"])
                });
            }
            return list;
        }

        // Fetch single doctor by ID
        public Doctor? GetDoctorById(int id)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_GetDoctorById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@DoctorID", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Doctor
                {
                    DoctorID = Convert.ToInt32(reader["DoctorID"]),
                    DoctorName = reader["DoctorName"].ToString() ?? "",
                    Specialization = reader["Specialization"].ToString() ?? "",
                    Phone = reader["Phone"].ToString() ?? "",
                    ExperienceYears = Convert.ToInt32(reader["ExperienceYears"])
                };
            }
            return null;
        }

        // Add new doctor via stored procedure
        public int AddDoctor(Doctor doctor)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_AddDoctor", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
            cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
            cmd.Parameters.AddWithValue("@Phone", doctor.Phone);
            cmd.Parameters.AddWithValue("@ExperienceYears", doctor.ExperienceYears);

            var outParam = new SqlParameter("@NewDoctorID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outParam);

            conn.Open();
            cmd.ExecuteNonQuery();

            return (int)outParam.Value;
        }

        // Update doctor information
        public bool UpdateDoctor(Doctor doctor)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_UpdateDoctor", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
            cmd.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
            cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
            cmd.Parameters.AddWithValue("@Phone", doctor.Phone);
            cmd.Parameters.AddWithValue("@ExperienceYears", doctor.ExperienceYears);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }

        // Remove doctor record
        public bool DeleteDoctor(int id)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_DeleteDoctor", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@DoctorID", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
    }
}
