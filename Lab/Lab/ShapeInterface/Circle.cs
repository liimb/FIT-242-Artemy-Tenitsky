namespace Lab.ShapeInterface;

public class Circle(string name) : NameClass(name), IPerimeterArea
{
    public double CalculatePerimeter(float value)
    {
        return 2 * Math.PI * value;
    }

    public double CalculateArea(float value)
    {
        return 2 * Math.PI * value * value;
    }
}