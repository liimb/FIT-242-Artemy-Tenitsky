namespace Lab.Files;

public class NumsEvenFile
{
    public static void Main(string[] args)
    {
        string input = "/Users/artemiy/Repositories/Politech/FIT-242-Artemy-Tenitsky/Lab/Lab/Files/input.txt";
        
        string[] lines = File.ReadAllLines(input);
        
        List<int> indexes = new List<int>();

        for (int i = 0; i < lines.Length; i++)
        {
            string number = "";
            
            foreach (var s in lines[i])
            {
                if (char.IsDigit(s))
                {
                    number += s.ToString();
                }
                else
                {
                    number += " ";
                }
            }
            
            int[] numbers = number
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (ArrayIsContainsEven(numbers))
            {
                indexes.Add(i);
            }
        }
        
        string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string outputPath = Path.Combine(projectDir, "nums.txt");

        using (StreamWriter output = new StreamWriter(outputPath))
        {
            foreach (var i in indexes)
            {
                output.WriteLine(lines[i]);
                Console.WriteLine(lines[i]);
            }
        }
        
        Console.WriteLine();
    }

    private static bool ArrayIsContainsEven(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
            {
                return true;
            }
        }
        
        return false;
    }
}