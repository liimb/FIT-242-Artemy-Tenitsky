using System.Security;

namespace Lab.StaplesStack;

public class StaplesChecker
{
    private static Dictionary<char, char> staplesMap = new Dictionary<char, char>()
    {
        {')', '('},
        {']', '['},
        {'}', '{'},
    };
    
    public void Main(string[] args)
    {
        String test1 = "1(23)j{d[j84]7}fb"; //true
        String test2 = "1(23)j{dj84]7}fb"; //false
        String test3 = "1(23j{dj84]7}fb"; //false
        
        Console.WriteLine(CheckStaple(test1));
        Console.WriteLine(CheckStaple(test2));
        Console.WriteLine(CheckStaple(test3));
    }

    private static bool CheckStaple(String test)
    {
        Stack<char> staplesStack = new Stack<char>();

        foreach (var sign in test)
        {
            if (sign == '(' || sign == '[' || sign == '{')
            {
                staplesStack.Push(sign);
            }
            else if (sign == ')' || sign == ']' || sign == '}')
            {
                if (staplesStack.Count > 0 && staplesStack.Peek() == staplesMap.GetValueOrDefault(sign, 'i'))
                {
                    staplesStack.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        if (staplesStack.Count > 0)
        {
            return false;
        }

        return true;
    }
}