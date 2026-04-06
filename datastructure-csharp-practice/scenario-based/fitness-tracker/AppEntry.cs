using System;
namespace FitnessController;

class AppEntry
{
    static void Main(string[] args)
    {
        FitnessController controller = new FitnessController();
        controller.StartMenu();
    }
}
