namespace Lab.UnsafeCode;

public unsafe class UnsafeArray
{
    public void Main()
    {
        Console.Write("Введите количество строк: ");
        int stringCount = int.Parse(Console.ReadLine()!);

        char*[] strs = new char*[stringCount];

        for (int i = 0; i < stringCount; i++)
        {
            Console.Write($"Введите строку [{i}]: ");
            string input = Console.ReadLine()!;

            fixed (char* charPtr = input)
            {
                strs[i] = charPtr;
            }
        }

        for (int i = 0; i < stringCount; i++)
        {
            string line = new string(strs[i]);

            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                continue;
            }

            string countPart = parts[^1];
            string elementPart = string.Join(' ', parts[..^1]);

            if (!int.TryParse(countPart, out int count))
            {
                continue;
            }

            Console.WriteLine($"{elementPart} повторяется {count} раз");
        }
    }
}
