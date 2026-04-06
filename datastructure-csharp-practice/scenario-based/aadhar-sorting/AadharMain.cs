using System;

public class AadharMain
{
    static void Main()
    {
        // Create an instance of the utility class to handle Aadhar operations
        AadharUtilityImpl utility = new AadharUtilityImpl();

        // Create the menu interface and pass the utility instance
        AadharMenu menu = new AadharMenu(utility);

        // Display the menu to the user
        menu.ShowMenu();
    }
}
