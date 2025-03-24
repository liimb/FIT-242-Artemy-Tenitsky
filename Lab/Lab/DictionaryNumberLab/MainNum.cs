namespace Lab.DictionaryNumberLab;

public class MainNum
{
    public delegate double FirstDelegate();
    public delegate double SecondDelegate();

    public static FirstDelegate FirstOperations;
    public static SecondDelegate SecondOperations;
    
    public void Main(string[] args)
    {
        List<Phone> phones = new List<Phone>();
        phones.Add(new Phone("+35987654321", "mts"));
        phones.Add(new Phone("+35987654321", "bb"));
        phones.Add(new Phone("+35987654321", "tele"));
        phones.Add(new Phone("+35987654321", "mts"));
        phones.Add(new Phone("+35987654321", "mts"));
        phones.Add(new Phone("+35987654321", "tele"));
        phones.Add(new Phone("+35987654321", "mts"));
        
        Dictionary<string, int> phoneDictionary = new Dictionary<string, int>();

        foreach (var p in phones)
        {
            if (!phoneDictionary.TryAdd(p.Operator, 1))
            {
                phoneDictionary[p.Operator] += 1;
            }
        }

        int a = 0;
        string op = "";
        
        foreach(var p in phoneDictionary)
        {
            if (p.Value > a)
            {
                op = p.Key;
                a = p.Value;
            }
        }
        
        Console.WriteLine($"итог: key: {op}  value: {a}");
        
        //////////////////////////
        //////////////////////////
        //////////////////////////

        BinaryOperations two = new BinaryOperations(5, 0);
        
        FirstOperations = two.Sum;
        FirstOperations += () => two.Minus(two.Sum());
        FirstOperations += () => two.Multiply(two.Minus(two.Sum()));
        
        SecondOperations = two.MultiplyTwo;
        SecondOperations += () => two.SumTwo(two.MultiplyTwo());
        SecondOperations += () => two.Divide(two.SumTwo(two.MultiplyTwo()));
        
        Console.WriteLine($"первый делегат {FirstOperations.Invoke()}");
        Console.WriteLine($"второй делегат {SecondOperations.Invoke()}");
    }
}
