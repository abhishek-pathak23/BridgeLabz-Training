using System;
using Microsoft.Data.SqlClient;

public class BillingService : IBillingService
{
    /// <summary>
    /// UC-5.1: Generate bill for a visit
    /// </summary>
    public void GenerateBill()
    {
        Console.Write("Enter Visit ID: ");
        int visitId = int.Parse(Console.ReadLine()!);

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string query = @"
            INSERT INTO Bills (visit_id, total_amount, payment_status)
            SELECT v.visit_id, d.consultation_fee, 'UNPAID'
            FROM Visits v
            JOIN Appointments a ON v.appointment_id = a.appointment_id
            JOIN Doctors d ON a.doctor_id = d.doctor_id
            WHERE v.visit_id = @vid";

        using SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@vid", visitId);
        cmd.ExecuteNonQuery();

        Console.WriteLine("✅ Bill generated successfully");
    }

    /// <summary>
    /// UC-5.2: Record payment
    /// </summary>
    public void RecordPayment()
    {
        Console.Write("Enter Bill ID: ");
        int billId = int.Parse(Console.ReadLine()!);

        Console.Write("Payment Mode (Cash/Card/UPI): ");
        string mode = Console.ReadLine()!;

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();
        SqlTransaction tx = con.BeginTransaction();

        try
        {
            string updateBill = @"
                UPDATE Bills 
                SET payment_status='PAID', payment_date=GETDATE()
                WHERE bill_id=@bid";

            using SqlCommand cmd = new SqlCommand(updateBill, con, tx);
            cmd.Parameters.AddWithValue("@bid", billId);
            cmd.ExecuteNonQuery();

            string insertPayment = @"
                INSERT INTO Payment_Transactions(bill_id, payment_mode, payment_date)
                VALUES(@bid, @mode, GETDATE())";

            using SqlCommand payCmd = new SqlCommand(insertPayment, con, tx);
            payCmd.Parameters.AddWithValue("@bid", billId);
            payCmd.Parameters.AddWithValue("@mode", mode);
            payCmd.ExecuteNonQuery();

            tx.Commit();
            Console.WriteLine("✅ Payment recorded");
        }
        catch
        {
            tx.Rollback();
            Console.WriteLine("❌ Payment failed");
        }
    }

    /// <summary>
    /// UC-5.3: View all outstanding bills
    /// </summary>
    public void ViewOutstandingBills()
    {
        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string query = @"
            SELECT p.name, COUNT(b.bill_id) AS Bills, SUM(b.total_amount) AS Due
            FROM Bills b
            JOIN Visits v ON b.visit_id = v.visit_id
            JOIN Appointments a ON v.appointment_id = a.appointment_id
            JOIN Patients p ON a.patient_id = p.patient_id
            WHERE b.payment_status='UNPAID'
            GROUP BY p.name";

        using SqlCommand cmd = new SqlCommand(query, con);
        using SqlDataReader rd = cmd.ExecuteReader();

        while (rd.Read())
        {
            Console.WriteLine($"{rd["name"]} | Bills: {rd["Bills"]} | Due: {rd["Due"]}");
        }
    }

    /// <summary>
    /// UC-5.4: Generate revenue report by date range
    /// </summary>
    public void GenerateRevenueReport()
    {
        Console.Write("From Date (yyyy-mm-dd): ");
        DateTime from = DateTime.Parse(Console.ReadLine()!);

        Console.Write("To Date (yyyy-mm-dd): ");
        DateTime to = DateTime.Parse(Console.ReadLine()!);

        using SqlConnection con = DbUtil.GetConnection();
        con.Open();

        string query = @"
            SELECT CAST(payment_date AS DATE) AS Day, SUM(total_amount) AS Revenue
            FROM Bills
            WHERE payment_status='PAID'
              AND payment_date BETWEEN @f AND @t
            GROUP BY CAST(payment_date AS DATE)
            HAVING SUM(total_amount) > 0";

        using SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@f", from);
        cmd.Parameters.AddWithValue("@t", to);

        using SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            Console.WriteLine($"{rd["Day"]} | Revenue: {rd["Revenue"]}");
        }
    }
}
