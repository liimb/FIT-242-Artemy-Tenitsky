namespace Lab.lambda;

public class Calculator
{
    public double Sum(double x, double y) => x + y;
    public double Subtrack(double x, double y) => x - y;
    public double Multiply(double x, double y) => x * y;
    public double Divide(double x, double y) => y != 0 ? x / y : double.NaN;
}