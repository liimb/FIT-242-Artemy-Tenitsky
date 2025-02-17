namespace Lab.ShapeInterface;

public class Square(string name) : NameClass(name), IPerimeterArea
{
    public double CalculatePerimeter(float value)
    {
        return 4 * value;
    }

    public double CalculateArea(float value)
    {
        return value * value;
    }
}