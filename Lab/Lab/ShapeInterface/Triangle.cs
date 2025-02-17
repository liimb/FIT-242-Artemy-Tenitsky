namespace Lab.ShapeInterface;

public class Triangle(string name, double length) : NameClass(name), IPerimeterArea
{
    public double Length { get; } = length;
    
    public double CalculatePerimeter(double value)
    {
        double perimeter = 3 * value;
        Console.WriteLine($"The perimeter of the Triangle is {perimeter}");
        return perimeter;
    }

    public double CalculateArea(double value)
    {
        double area = Math.Sqrt(3) * value * value / 4;
        Console.WriteLine($"The area of the Triangle is {area}");
        return area;
    }
}