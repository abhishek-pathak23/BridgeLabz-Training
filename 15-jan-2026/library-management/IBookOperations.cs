namespace library_management_review.library_management
{
    interface IBookOperations
    {
        void DisplayBooks();
        void SearchBook(string title);
        void CheckoutBook(int id);
        void AddBook();
    }
}
