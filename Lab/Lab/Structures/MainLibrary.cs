namespace Lab.Structures;

public class MainLibrary
{
    private static void Main(string[] args)
    {
        var book1 = new Book("1", "a", "", "");
        var book2 = new Book("2", "b", "", "");
        var book3 = new Book("3", "c", "", "");
        var book4 = new Book("4", "d", "", "");
        
        var blank1 = new Blank( "2023-01-15", "");
        var blank2 = new Blank("2023-01-20", "2023-02-16");

        BookLib b1 = new BookLib(book1);
        b1.Blanks.Add(blank1);
        
        BookLib b2 = new BookLib(book2);
        b2.Blanks.Add(blank2);
        
        BookLib b3 = new BookLib(book3);
        
        BookLib b4 = new BookLib(book4);
        
        var books = new List<BookLib> { b1, b2, b3, b4 };
        
        var library = new Library(books);
        
        Console.WriteLine("\nКниги на руках:");
        PrintBooks(library.GetAllOnHandsBooks());
        
        Console.WriteLine("\nНевыданные книги:");
        PrintBooks(library.GetAllUnreleasedBooks());
    }
    
    static void PrintBooks(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("нет книг");
            return;
        }
        
        foreach (var book in books)
        {
            Console.WriteLine($"- {book.Name} ({book.Author})");
        }
    }
}