namespace Lab.Structures;

public struct Book(string author, string name, string date, string publisher)
{
    public readonly string Author = author;
    public readonly string Name = name;
    public readonly string Date = date;
    public readonly string Publisher = publisher;
}