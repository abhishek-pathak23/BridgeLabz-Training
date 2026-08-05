using System;
using HealthClinicApp.Entity;
using HealthClinicApp.Service;

namespace HealthClinicApp.Menu
{
    public class DoctorMenu
    {
        private readonly DoctorService _doctorService;

        public DoctorMenu(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- DOCTOR & SPECIALTY MANAGEMENT ---");
                Console.ResetColor();
                Console.WriteLine(" 1. View All Doctors");
                Console.WriteLine(" 2. Add New Doctor");
                Console.WriteLine(" 3. Update Doctor Information");
                Console.WriteLine(" 4. Delete Doctor Record");
                Console.WriteLine(" 0. Back to Main Menu");
                Console.Write(" Select Choice: ");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllDoctors();
                        Pause();
                        break;
                    case "2":
                        AddDoctor();
                        Pause();
                        break;
                    case "3":
                        UpdateDoctor();
                        Pause();
                        break;
                    case "4":
                        DeleteDoctor();
                        Pause();
                        break;
                    case "0":
                        return;
                    default:
                        ShowError("Invalid choice.");
                        break;
                }
            }
        }

        private void ViewAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            Console.WriteLine("\n--- LIST OF DOCTORS & SPECIALTIES ---");
            Console.WriteLine(string.Format("{0,-6} | {1,-22} | {2,-18} | {3,-12} | {4,-10}", "ID", "Doctor Name", "Specialization", "Phone", "Exp (Yrs)"));
            Console.WriteLine(new string('-', 78));

            foreach (var d in doctors)
            {
                Console.WriteLine(string.Format("{0,-6} | {1,-22} | {2,-18} | {3,-12} | {4,-10}",
                    d.DoctorID, d.DoctorName, d.Specialization, d.Phone, d.ExperienceYears));
            }
        }

        private void AddDoctor()
        {
            Console.WriteLine("\n--- ADD NEW DOCTOR ---");
            Console.Write("Doctor Name (e.g. Dr. John Doe): ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Specialization (e.g. Cardiology, Neurology): ");
            string spec = Console.ReadLine() ?? "";

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine() ?? "";

            Console.Write("Years of Experience: ");
            int.TryParse(Console.ReadLine(), out int exp);

            try
            {
                int newId = _doctorService.AddDoctor(new Doctor
                {
                    DoctorName = name,
                    Specialization = spec,
                    Phone = phone,
                    ExperienceYears = exp
                });
                ShowSuccess($"Doctor added successfully! Doctor ID: {newId}");
            }
            catch (Exception ex)
            {
                ShowError("Error adding doctor: " + ex.Message);
            }
        }

        private void UpdateDoctor()
        {
            Console.Write("\nEnter Doctor ID to Update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                ShowError("Invalid ID!");
                return;
            }

            var doc = _doctorService.GetDoctorById(id);
            if (doc == null)
            {
                ShowError("Doctor not found!");
                return;
            }

            Console.WriteLine($"Updating Doctor: {doc.DoctorName}");
            Console.Write($"Doctor Name [{doc.DoctorName}]: ");
            string name = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(name)) doc.DoctorName = name;

            Console.Write($"Specialization [{doc.Specialization}]: ");
            string spec = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(spec)) doc.Specialization = spec;

            Console.Write($"Phone [{doc.Phone}]: ");
            string ph = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(ph)) doc.Phone = ph;

            Console.Write($"Experience [{doc.ExperienceYears}]: ");
            string expStr = Console.ReadLine() ?? "";
            if (int.TryParse(expStr, out int exp)) doc.ExperienceYears = exp;

            bool updated = _doctorService.UpdateDoctor(doc);
            if (updated)
                ShowSuccess("Doctor record updated!");
            else
                ShowError("Failed to update doctor.");
        }

        private void DeleteDoctor()
        {
            Console.Write("\nEnter Doctor ID to Delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                ShowError("Invalid ID!");
                return;
            }

            Console.Write($"Delete Doctor #{id}? (y/N): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                bool deleted = _doctorService.DeleteDoctor(id);
                if (deleted)
                    ShowSuccess("Doctor deleted successfully!");
                else
                    ShowError("Could not delete doctor.");
            }
        }

        private static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ERROR] " + msg);
            Console.ResetColor();
        }

        private static void ShowSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[SUCCESS] " + msg);
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress Enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
