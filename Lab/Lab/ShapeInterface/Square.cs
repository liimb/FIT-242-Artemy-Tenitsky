namespace Lab.ShapeInterface;

public class Square(string name, double length) : NameClass(name), IPerimeterArea
{
    public double Length { get; } = length;
    
    public double CalculatePerimeter(double value)
    {
        double perimeter = 4 * value;
        Console.WriteLine($"The perimeter of the Square is {perimeter}");
        return perimeter;
    }

    public double CalculateArea(double value)
    {
        double area = value * value;
        Console.WriteLine($"The area of the Square is {area}");
        return area;
    }
}