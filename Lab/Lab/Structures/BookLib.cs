namespace Lab.Structures;

public class BookLib(Book book)
{
    public Book MyBook { get; set; } = book;
    
    public List<Blank> Blanks { get; set; } = new List<Blank>();
}