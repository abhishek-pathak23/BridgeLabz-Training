using ExamProctor.Menu; // Imports the menu-related classes used in the application

namespace ExamProctor
{
    class ExamMain
    {
        static void Main()
        {
            // Create an object of ExamMenu to control program navigation
            ExamMenu menu = new ExamMenu();

            // Start the application by displaying the main menu
            menu.Show();
        }
    }
}
