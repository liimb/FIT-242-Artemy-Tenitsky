using System.Text;

namespace Lab.UnsafeCode;

public unsafe class UnsafePalindrom
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите кол-во элементов");
        
        int size = int.Parse(Console.ReadLine());

        int* nums = stackalloc int[size];
        
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Введите элемент [{i}]: ");
            nums[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nПалиндромы в массиве:");
        for (int i = 0; i < size; i++)
        {
            int value = *(nums + i);
            if (IsPalindrome(value))
            {
                Console.WriteLine($"[{i}] = {value}");
            }
        }
    }

    private static bool IsPalindrome(int num)
    {
        var sb = new StringBuilder();
        string input = num.ToString();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            sb.Append(input[i]);
        }
        
        return input == sb.ToString();
    }
}
