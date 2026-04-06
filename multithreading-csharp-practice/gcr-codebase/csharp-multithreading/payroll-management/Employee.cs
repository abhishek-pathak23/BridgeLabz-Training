using System.Data;
using System.Data.SqlClient;
namespace PayrollService
{
    public class Employee
    {
        public int Id { get; set; }           // optional for DB identity
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }
    }
}
