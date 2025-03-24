namespace Lab.EventLab.SquarePoint;

public class EventPointOutside
{
    public static void DisplayMessage(Point p) => Console.WriteLine($"точка {p.X} {p.Y} за пределами поля");
}