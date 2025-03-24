namespace Lab.StackPlusHashSetDictionary;

public class UniqueElements
{
    public void PrintUniqueElements(List<int> elements)
    {
        HashSet<int> unique = new(elements);

        Console.WriteLine("уникальные элементы:");
        
        foreach (var num in unique)
        {
            Console.WriteLine(num);
        }
    }

    public void PrintFrequencyOfCccurrence(List<int> elements)
    {
        Dictionary<int, int> frequency = new();

        foreach (var num in elements)
        {
            if (!frequency.ContainsKey(num))
            {
                frequency.Add(num, 1);
            }
            else
            {
                frequency[num]++;
            }
        }
        
        Console.WriteLine("частота:");

        foreach (var num in frequency)
        {
            Console.WriteLine($"num: {num.Key}  frequency: {num.Value}");
        }
    }
}
