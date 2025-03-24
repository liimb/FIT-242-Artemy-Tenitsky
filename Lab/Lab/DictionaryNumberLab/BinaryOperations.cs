namespace Lab.DictionaryNumberLab;

public class BinaryOperations
{
    public BinaryOperations(double a, double b)
    {
        A = a;
        B = b;
    }
    
    private double A { get; set; }
    private double B { get; set; }
    
    public double Sum() => A + B;
    public double Minus(double sum) => sum - B;
    public double Multiply(double minus) => minus * B;
    
    public double MultiplyTwo() => A * B;
    public double SumTwo(double multi) => multi + B;

    public double Divide(double sum)
    {
        if (B != 0)
        {
            return sum / B;
        }
        
        Console.WriteLine("деление на ноль");

        return double.NaN;
    }
}
