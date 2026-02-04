using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace PayrollService
{
    // Interface for Employee Payroll Service
    public interface IEmployeePayrollService
    {
        void AddEmployee(Employee employee);                     // UC1 & UC2
        void AddEmployeesWithThreads(List<Employee> employees);  // UC2, UC3, UC4
        void AddEmployeeWithDetails(Employee employee);          // UC5
        void UpdateEmployeeSalary(Employee employee);            // UC6
    }
}
