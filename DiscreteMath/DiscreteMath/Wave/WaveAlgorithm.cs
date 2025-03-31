namespace DiscreteMath.Wave;

public class WaveAlgorithm
{
    public static void Main(string[] args)
    {
        string[,] field =
        {
            { "x", "x", "x", "x", "x", "x", "x" },
            { "x", "-", "-", "-", "x", "x", "x" },
            { "x", "-", "x", "-", "-", "-", "x" },
            { "x", "-", "x", "-", "x", "-", "x" },
            { "x", "-", "0", "-", "x", "e", "x" },
            { "x", "-", "-", "-", "x", "-", "x" },
            { "x", "x", "x", "x", "x", "x", "x" }
        };
        
        GetMinPath(field);
    }

    public static void GetMinPath(string[,] field)
    {
        int rows = field.GetLength(0);
        int cols = field.GetLength(1);
        
        for (int step = 0; step < rows * cols; step++)
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    int i;
                    
                    bool t = int.TryParse(field[x, y], out i);

                    if (t && i == step)
                    {
                        if (field[x + 1, y] != "x")
                        {
                            if (field[x + 1, y] == "e")
                            {
                                Console.WriteLine($"Путь: {step + 1}");
                                PrintField(field);
                                return;
                            }

                            if (field[x + 1, y] == "-")
                            {
                                int a = step + 1;
                                field[x + 1, y] = a.ToString();
                            }
                        }

                        if (field[x - 1, y] != "x")
                        {
                            if (field[x - 1, y] == "e")
                            {
                                Console.WriteLine($"Путь: {step + 1}");
                                PrintField(field);
                                return;
                            }

                            if (field[x - 1, y] == "-")
                            {
                                int a = step + 1;
                                field[x - 1, y] = a.ToString();
                            }
                        }

                        if (field[x, y + 1] != "x")
                        {
                            if (field[x, y + 1] == "e")
                            {
                                Console.WriteLine($"Путь: {step + 1}");
                                PrintField(field);
                                return;
                            }

                            if (field[x, y + 1] == "-")
                            {
                                int a = step + 1;
                                field[x, y + 1] = a.ToString();
                            }
                        }

                        if (field[x, y - 1] != "x")
                        {
                            if (field[x, y - 1] == "e")
                            {
                                Console.WriteLine($"Путь: {step + 1}");
                                PrintField(field);
                                return;
                            }

                            if (field[x, y - 1] == "-")
                            {
                                int a = step + 1;
                                field[x, y - 1] = a.ToString();
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("Путь не найден");

        PrintField(field);
    }
    
    public static void PrintField(string[,] field)
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}