using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Data;
namespace PayrollService
{
    public class EmployeePayrollService : IEmployeePayrollService
    {
        private static string connectionString = "Server=YOUR_SERVER;Database=payroll_service;Trusted_Connection=True;";
        private static object lockObj = new object();   // for synchronization

        // UC1: Add employee normally
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = $"INSERT INTO employee_payroll (name,salary) VALUES ('{employee.Name}',{employee.Salary})";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine($"Added Employee: {employee.Name}");
        }

        // UC2-UC4: Add employees with threads
        public void AddEmployeesWithThreads(List<Employee> employees)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<Thread> threads = new List<Thread>();
            foreach (var emp in employees)
            {
                Thread t = new Thread(() => AddEmployee(emp));
                threads.Add(t);
                t.Start();
            }

            foreach (var t in threads) t.Join();

            sw.Stop();
            Console.WriteLine($"Time taken with threads: {sw.ElapsedMilliseconds} ms");
        }

        // UC5: Add employee to payroll and payroll_details with synchronization
        public void AddEmployeeWithDetails(Employee employee)
        {
            lock (lockObj)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // Insert into employee_payroll and get ID
                    string query1 = $"INSERT INTO employee_payroll (name,salary) OUTPUT INSERTED.id VALUES ('{employee.Name}',{employee.Salary})";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    int empId = (int)cmd1.ExecuteScalar();

                    // Insert into payroll_details
                    string query2 = $"INSERT INTO payroll_details (employee_id,bonus) VALUES({empId}, 5000)";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                }
                Console.WriteLine($"Added Employee with details: {employee.Name}");
            }
        }

        // UC6: Update employee salary with threads
        public void UpdateEmployeeSalary(Employee employee)
        {
            lock (lockObj)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query1 = $"UPDATE employee_payroll SET salary={employee.Salary} WHERE name='{employee.Name}'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();

                    string query2 = $"UPDATE payroll_details SET bonus={employee.Salary*0.1} WHERE employee_id=(SELECT id FROM employee_payroll WHERE name='{employee.Name}')";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                }
                Console.WriteLine($"Updated Salary for Employee: {employee.Name}");
            }
        }
    }
}
