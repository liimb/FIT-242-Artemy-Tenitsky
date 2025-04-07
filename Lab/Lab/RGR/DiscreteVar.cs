namespace Lab.RGR;

public class DiscreteVar
{
    public static void Main(string[] args)
    {
        string path = "/Users/artemiy/Repositories/Polikek/FIT-242-Artemy-Tenitsky/Lab/Lab/RGR/inputDis.txt";
        string[] input = File.ReadAllLines(path);
        
        int n = int.Parse(input[0]);
        
        int[,] graph = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] row = input[i + 1].Split(' ');
            
            for (int j = 0; j < n; j++)
            {
                graph[i, j] = int.Parse(row[j]);
            }
        }
        
        int verticesCount = graph.GetLength(0);
        int[,] paths = (int[,])graph.Clone();
        
        for (int k = 0; k < verticesCount; k++)
        {
            for (int x = 0; x < verticesCount; x++)
            {
                for (int y = 0; y < verticesCount; y++)
                {
                    if (paths[x, k] != int.MaxValue && paths[k, y] != int.MaxValue && x != y)
                    {
                        paths[x, y] = Math.Min(paths[x, k] + paths[k, y], paths[x, y]);
                    }
                }
            }
            
            PrintArray(paths);
        }
    }
    
    public static void PrintArray(int[,] array)
    {
        int rows = array.GetLength(0);

        Console.Write("    ");
        for (int j = 0; j < rows; j++)
            Console.Write($"{j,4} ");
        Console.WriteLine("\n   " + new string('-', rows * 5));

        for (int i = 0; i < rows; i++)
        {
            Console.Write($"{i} |");
            for (int j = 0; j < rows; j++)
            {
                Console.Write($"{array[i, j], 4} ");
            }
            Console.WriteLine();
        }
    }
}