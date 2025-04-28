namespace DiscreteMath.FloidAlg;

public class FloidPaths
{
    public static void Main(string[] args)
    {
        int[,] graphi =
        {
            { int.MaxValue, 3, int.MaxValue, int.MaxValue, 2,3,int.MaxValue }, 
            { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, -4,6,int.MaxValue }, 
            { int.MaxValue, -2, int.MaxValue, 7, int.MaxValue,10,int.MaxValue },
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue,int.MaxValue,2 },
            {int.MaxValue, int.MaxValue, 4, int.MaxValue, int.MaxValue,int.MaxValue,int.MaxValue},
            {int.MaxValue,int.MaxValue,int.MaxValue,-2,int.MaxValue,int.MaxValue,int.MaxValue},
            {int.MaxValue,int.MaxValue,-8,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue}
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