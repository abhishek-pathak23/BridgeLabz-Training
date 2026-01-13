// Interface defines the allowed operations
public interface IBookService
{
    void AddBook(string title, string author);
    void SortBooksAlphabetically();
    void SearchByAuthor(string author);
    void ExportBooks();
}
