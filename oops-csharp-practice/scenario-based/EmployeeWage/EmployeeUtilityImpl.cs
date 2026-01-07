namespace EmployeeWage;
public class EmployeeUtilityImpl:IEmployee
{

    private const int WagePerHour = 20;
    private const int FullDayHours = 8;
    private const int PartTimeHours = 4;
    private const int MaxWorkingDays = 20;
    private const int MaxWorkingHours = 100;

    private Employee employee;
    private Random random = new Random();
    public EmployeeUtilityImpl(Employee employee)
    {
        this.employee = employee;
    }
    //uc1:Check Employee is Present or Absent using random
     public void CheckAttendance()
{
    
    int attendance = random.Next(0, 2);
    Console.WriteLine(attendance == 1? "Employee is Present": "Employee is Absent");
}

//uc 2:calculate daily employee wage
 public void CalculateDailyWage()
    {
        int dailyWage = WagePerHour * FullDayHours;
        Console.WriteLine($"Daily Wage : {dailyWage}");
    }

}