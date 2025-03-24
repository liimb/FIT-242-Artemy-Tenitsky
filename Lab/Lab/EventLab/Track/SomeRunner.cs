namespace Lab.EventLab.Track;

public class SomeRunner(int speed, int startX, string name)
{
    public string Name { get; } = name;
    public int Speed { get; } = speed;
    
    public int CurrentX {get; set;} = startX;
}
