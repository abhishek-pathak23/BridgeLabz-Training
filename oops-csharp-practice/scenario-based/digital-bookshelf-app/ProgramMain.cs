using System;

// Program starts here
class ProgramMain
{
    static void Main()
    {
        IBookService bookService = new BookService(); // Loose coupling
        MenuHandler.ShowMenu(bookService);            // Start menu
    }
}
