using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entity;
using HealthClinicApp.Interface;

namespace HealthClinicApp.Service
{
    public class PatientService : IPatientService
    {
        private readonly DBConnectionUtility _dbUtility;

        public PatientService(DBConnectionUtility dbUtility)
        {
            _dbUtility = dbUtility;
        }

        private SqlConnection GetConnection() => _dbUtility.CreateConnection();

        public List<Patient> GetAllPatients()
        {
            var list = new List<Patient>();
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_GetAllPatients", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Patient
                {
                    PatientID = Convert.ToInt32(reader["PatientID"]),
                    FirstName = reader["FirstName"].ToString() ?? "",
                    LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() ?? "" : "",
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                    Gender = reader["Gender"].ToString() ?? "",
                    Phone = reader["Phone"].ToString() ?? ""
                });
            }
            return list;
        }

        public Patient? GetPatientById(int id)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_GetPatientById", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@PatientID", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Patient
                {
                    PatientID = Convert.ToInt32(reader["PatientID"]),
                    FirstName = reader["FirstName"].ToString() ?? "",
                    LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() ?? "" : "",
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                    Gender = reader["Gender"].ToString() ?? "",
                    Phone = reader["Phone"].ToString() ?? ""
                };
            }
            return null;
        }

        public int AddPatient(Patient patient)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_AddPatient", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
            cmd.Parameters.AddWithValue("@LastName", (object?)patient.LastName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", patient.Gender);
            cmd.Parameters.AddWithValue("@Phone", patient.Phone);

            var outParam = new SqlParameter("@NewPatientID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outParam);

            conn.Open();
            cmd.ExecuteNonQuery();

            return (int)outParam.Value;
        }

        public bool UpdatePatient(Patient patient)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_UpdatePatient", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@PatientID", patient.PatientID);
            cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
            cmd.Parameters.AddWithValue("@LastName", (object?)patient.LastName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", patient.Gender);
            cmd.Parameters.AddWithValue("@Phone", patient.Phone);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }

        public bool DeletePatient(int id)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_DeletePatient", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@PatientID", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
    }
}
