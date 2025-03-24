namespace Lab.EventLab.SquarePoint;

public class MainSquareChecker
{
    public void Main(string[] args)
    {
        Square square = new Square(10, 20, 123, 145);
        Point point = new Point(10, 20);
        Random random = new Random();
        EventPoint eventPoint = new EventPoint();
        
        while (IsPointOutsideSquare(square, point))
        {
            point.X = random.Next(-2000, 2001);
            point.Y = random.Next(-2000, 2001);
        }
        
        eventPoint.DisplayPoint += EventPointOutside.DisplayMessage;
        eventPoint.OnEvent(point);
    }

    private static bool IsPointOutsideSquare(Square s, Point p)
    {
        return p.X < s.X + s.Width && p.X > s.X - s.Width &&
               p.Y < s.Y + s.Height && p.Y > s.Y - s.Height;
    }
}