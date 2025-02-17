namespace Lab.ShapeInterface;

public class Triangle(string name) : NameClass(name), IPerimeterArea
{
    public double CalculatePerimeter(float value)
    {
        return 3 * value;
    }

    public double CalculateArea(float value)
    {
        return Math.Sqrt(3) * value * value / 4;
    }
}