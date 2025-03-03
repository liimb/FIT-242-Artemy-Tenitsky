namespace Lab.StackPlusHashSetDictionary;

public class Initializer
{
    public static void Main(string[] args)
    {
        PolishExpression expression = new PolishExpression();
        expression.GetPolishExpressionValue("3 2 * 5 +");
        
        UniqueElements uniqueElements = new UniqueElements();
        uniqueElements.PrintUniqueElements([1, 1, 3, 2, 3, 3, 4, 5, 5, 1, 2, 3]);
        uniqueElements.PrintFrequencyOfCccurrence([1, 1, 3, 2, 3, 3, 4, 5, 5, 1, 2, 3]);
    }
}