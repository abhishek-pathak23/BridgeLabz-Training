namespace library_management_review.library_management
{
    class Book
    {
        public int Id;
        public string Title;
        public string Author;
        public bool IsAvailable;

        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
            IsAvailable = true;
        }
    }
}
