namespace DiscreteMath.FloidAlg;

public class FloidPaths
{
    public void Main(string[] args)
    {
        int[,] graphi =
        {
            { 0, 2, int.MaxValue, 19, 19 }, 
            { 2, 0, 6, 14, int.MaxValue }, 
            { 21, 6, 0, 1, 13 },
            {int.MaxValue, 6, 1, 0, 2 },
            {7, 11, 6, 2, 0},
        };
        
        GetMinPaths(graphi);
    }
    
    public static int[,] GetMinPaths(int[,] graph)
    {
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

        return paths;
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