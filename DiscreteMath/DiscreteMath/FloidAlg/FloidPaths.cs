namespace DiscreteMath.FloidAlg;

public class FloidPaths
{
    public static void Main(string[] args)
    {
        double[,] graph =
        {
            { 0, 10, 18, 8, double.PositiveInfinity, double.PositiveInfinity }, 
            { 10, 0, 16, 9, 21, double.PositiveInfinity }, 
            { double.PositiveInfinity, 16, 0, double.PositiveInfinity, double.PositiveInfinity, 15 },
            {7, 9, double.PositiveInfinity, 0, double.PositiveInfinity, 12},
            {double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, 0, 23},
            {double.PositiveInfinity, double.PositiveInfinity, 15, double.PositiveInfinity,23,0}
        };
        
        int[,] graphi =
        {
            { 0, 10, 18, 8, int.MaxValue, int.MaxValue }, 
            { 10, 0, 16, 9, 21, int.MaxValue }, 
            { int.MaxValue, 16, 0, int.MaxValue, int.MaxValue, 15 },
            {7, 9, int.MaxValue, 0, int.MaxValue, 12},
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 0, 23},
            {int.MaxValue, int.MaxValue, 15, int.MaxValue,23,0}
        };
        
        PrintArray(GetMinPaths(graphi));
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
                    if (paths[x, k] != int.MaxValue && paths[k, y] != int.MaxValue)
                    {
                        paths[x, y] = Math.Min(paths[x, k] + paths[k, y], paths[x, y]);
                    }
                }
            }
        }

        return paths;
    }
    
    static void PrintArray(int[,] array)
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