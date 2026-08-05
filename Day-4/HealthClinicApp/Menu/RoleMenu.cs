using System;

namespace HealthClinicApp.Menu
{
    // Role selector - the first screen the user sees when launching the app
    public class RoleMenu
    {
        private readonly HealthMenu _adminMenu;
        private readonly DoctorRoleMenu _doctorRoleMenu;
        private readonly PatientRoleMenu _patientRoleMenu;

        public RoleMenu(HealthMenu adminMenu, DoctorRoleMenu doctorRoleMenu, PatientRoleMenu patientRoleMenu)
        {
            _adminMenu = adminMenu;
            _doctorRoleMenu = doctorRoleMenu;
            _patientRoleMenu = patientRoleMenu;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========================================================");
                Console.WriteLine("           HEALTH CLINIC MANAGEMENT APP                  ");
                Console.WriteLine("=========================================================");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("  Who are you?");
                Console.WriteLine();
                Console.WriteLine("  1.  Admin");
                Console.WriteLine("  2.  Doctor");
                Console.WriteLine("  3.  Patient");
                Console.WriteLine("  0.  Exit");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("  Select Role [0-3]: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _adminMenu.Run();
                        break;
                    case "2":
                        _doctorRoleMenu.Display();
                        break;
                    case "3":
                        _patientRoleMenu.Display();
                        break;
                    case "0":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nGoodbye!");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[ERROR] Invalid choice. Press Enter to retry.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
