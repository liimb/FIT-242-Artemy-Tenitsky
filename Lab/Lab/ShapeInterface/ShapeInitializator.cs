namespace Lab.ShapeInterface;

public class ShapeInitializator
{
    public static void Main(string[] args)
    {
        Circle circle = new Circle("circle", 3d);
        Square square = new Square("square", 3d);
        Triangle triangle = new Triangle("triangle", 3d);

        circle.CalculatePerimeter(circle.Radius);
        circle.CalculateArea(circle.Radius);
        
        square.CalculatePerimeter(square.Length);
        square.CalculateArea(square.Length);    
        
        triangle.CalculatePerimeter(triangle.Length);
        triangle.CalculateArea(triangle.Length);    
    }
}