namespace Lab.UsersLINQ;

public class Computer(int id, string name, string date, string operationSystem)
{
    public int Id { get; set; } = id;
    public string Brand { get; set; } = name;
    public string Date { get; set; } = date;
    public string OperationSystem { get; set; } = operationSystem;
}