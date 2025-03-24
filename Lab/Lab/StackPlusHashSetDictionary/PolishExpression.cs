using System.Collections;

namespace Lab.StackPlusHashSetDictionary;

public class PolishExpression
{
    public void GetPolishExpressionValue(string expression)
    {
        Stack<double> stack = new();

        foreach (var str in expression.Split(" "))
        {
            if (str == "+" || str == "-" || str == "*" || str == "/")
            {
                if (stack.Count < 2)
                {
                    Console.WriteLine("неверное выражение");
                    break;
                }
                
                double v2 = stack.Pop();
                double v1 = stack.Pop();

                switch (str)
                {
                    case "+":
                        stack.Push(v1 + v2);
                        break;
                    
                    case "*":
                        stack.Push(v1 * v2);
                        break;
                    
                    case "-":
                        stack.Push(v1 - v2);
                        break;
                    
                    case "/":
                        if (v2 == 0)
                        {
                            Console.WriteLine(double.PositiveInfinity + "деление на нуль");
                            return;
                        }

                        stack.Push(v1 / v2);
                        
                        break;
                }
            }
            if (double.TryParse(str, out double value))
            {
                stack.Push(value);
            }
        }

        if (stack.Count == 1)
        {
            double result = stack.Pop();
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("неверное выражение");
        }
    }
}
