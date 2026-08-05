using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthClinicApp.Entity;

namespace HealthClinicApp.Service
{
    public class BillingService
    {
        private readonly string _connectionString;

        public BillingService(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        // Fetch all billing invoices
        public List<Billing> GetAllBills()
        {
            var list = new List<Billing>();
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_GetAllBills", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Billing
                {
                    BillID = Convert.ToInt32(reader["BillID"]),
                    AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                    PatientName = reader["PatientName"].ToString() ?? "",
                    DoctorName = reader["DoctorName"].ToString() ?? "",
                    ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"]),
                    TaxAmount = Convert.ToDecimal(reader["TaxAmount"]),
                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                    PaymentStatus = reader["PaymentStatus"].ToString() ?? "",
                    BillingDate = Convert.ToDateTime(reader["BillingDate"])
                });
            }
            return list;
        }

        // Generate a new bill manually using stored procedure
        public int GenerateBill(int appointmentId, decimal consultationFee, decimal taxAmount)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_GenerateBill", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
            cmd.Parameters.AddWithValue("@ConsultationFee", consultationFee);
            cmd.Parameters.AddWithValue("@TaxAmount", taxAmount);

            var outParam = new SqlParameter("@NewBillID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outParam);

            conn.Open();
            cmd.ExecuteNonQuery();

            return (int)outParam.Value;
        }

        // Update payment status (Pending / Paid / Cancelled)
        public bool UpdateBillPaymentStatus(int billId, string paymentStatus)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("sp_UpdateBillPaymentStatus", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@BillID", billId);
            cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
    }
}
