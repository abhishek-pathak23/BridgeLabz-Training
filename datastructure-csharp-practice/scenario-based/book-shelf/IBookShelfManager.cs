namespace BridgeLabzDup.datastructure_csharp_practice.scenario_based.book_shelf;

// Defines operations for library management
public interface IBookShelfManager
{
    void AddBook(string genre, string bookName);
    void BorrowBook(string genre, string bookName);
    void ShowCatalog();
}
