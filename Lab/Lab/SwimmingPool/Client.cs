namespace Lab.SwimmingPool;

public struct Client(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}