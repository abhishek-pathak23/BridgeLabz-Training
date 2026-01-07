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


//uc3:add part time employee and  wage
public void AddPartTimeEmployee()
    {
        int partTimeWage = WagePerHour * PartTimeHours;
        Console.WriteLine($"Part Time Wage : {partTimeWage}");
    }

    //uc 4:calculate using switch case
     public void CalculateUsingSwitch()
    {
        int workType = random.Next(0, 3);
        int hoursWorked = 0;

        switch (workType)
        {
            case 1:
                hoursWorked = FullDayHours;
                Console.WriteLine("Full Time Employee");
                break;

            case 2:
                hoursWorked = PartTimeHours;
                Console.WriteLine("Part Time Employee");
                break;

            default:
                Console.WriteLine("Employee is Absent");
                break;
        }

        Console.WriteLine($"Wage : {hoursWorked * WagePerHour}");
    }
//uc 5:Calculating Wages for a Month
    public void CalculateMonthlyWage()
    {
        int monthlyWage = WagePerHour * FullDayHours * MaxWorkingDays;
        Console.WriteLine($"Monthly Wage : {monthlyWage}");
    }

}