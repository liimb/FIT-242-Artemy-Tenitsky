namespace Lab.ShapeInterface;

public class Circle(string name, double radius) : NameClass(name), IPerimeterArea
{
    public double Radius { get; } = radius;
    
    public double CalculatePerimeter(double value)
    {
        double perimeter = 2 * Math.PI * value;
        Console.WriteLine($"The perimeter of the Circle is {perimeter}");
        return perimeter;
    }

    public double CalculateArea(double value)
    {
        double area = 2 * Math.PI * value * value;
        Console.WriteLine($"The perimeter of the Circle is {area}");
        return area;
    }
}
