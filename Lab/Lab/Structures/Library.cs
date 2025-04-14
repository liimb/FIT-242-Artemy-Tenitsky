namespace Lab.Structures;

public class Library
{
    public List<BookLib> Books { get; private set; }
    
    public Library(List<BookLib> books)
    {
        Books = books;
    }

    public List<Book> GetAllUnreleasedBooks()
    {
        List<Book> books = new List<Book>();
        
        foreach (var book in Books)
        {
            if (book.Blanks.Count == 0)
            {
                books.Add(book.MyBook);
            }
        }
        
        return books;
    }
    
    public List<Book> GetAllOnHandsBooks()
    {
        List<Book> books = new List<Book>();
        
        foreach (var bookLib in Books)
        {
            foreach (var blank in bookLib.Blanks)
            {
                if (string.IsNullOrEmpty(blank.ReturnDate))
                {
                    books.Add(bookLib.MyBook);
                    break;
                }
            }
        }
        
        return books;
    }
}