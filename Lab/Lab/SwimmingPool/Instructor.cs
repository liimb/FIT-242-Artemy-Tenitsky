namespace Lab.SwimmingPool;

public struct Instructor(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}