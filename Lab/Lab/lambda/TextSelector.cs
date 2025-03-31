namespace Lab.lambda;

public class TextSelector
{
    public static List<string> SelectBy(List<string> list, string start) => 
        new List<string>(list.FindAll(s => s.StartsWith(start)));
}