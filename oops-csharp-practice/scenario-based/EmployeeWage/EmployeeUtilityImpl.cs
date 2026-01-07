namespace EmployeeWage;
public class EmployeeUtilityImpl:IEmployee
{
    private Employee employee;
    private Random random = new Random();
    public EmployeeUtilityImpl(Employee employee)
    {
        this.employee = employee;
    }
     public void CheckAttendance()
{
    
    int attendance = random.Next(0, 2);
    Console.WriteLine(attendance == 1? "Employee is Present": "Employee is Absent");
}

}