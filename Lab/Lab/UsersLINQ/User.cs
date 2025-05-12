namespace Lab.UsersLINQ;

public class User(int id, string name, string date,bool isHasComp, int computerId)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Date { get; set; } = date;
    public bool IsHasComputer { get; set; } = isHasComp;
    public int ComputerId { get; set; } = computerId;
}