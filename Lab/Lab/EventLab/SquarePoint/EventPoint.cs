namespace Lab.EventLab.SquarePoint;

public delegate void PointDelegate(Point p);

public class EventPoint
{
    public event PointDelegate DisplayPoint;
    
    public void OnEvent(Point p)
    {
        if (DisplayPoint != null)
        {
            DisplayPoint(p);
        }
    }
}
