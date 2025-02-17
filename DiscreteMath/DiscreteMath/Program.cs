namespace DiscreteMath;

public static class Program
{
    private static void Main(string[] args)
    {
        int[,] graph = // 3
        {
            {0, 1, 0, 0},
            {1, 0, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        };
        
        int[,] graph1 = // 1
        {
            {0, 1, 1, 0},
            {1, 0, 1, 1},
            {1, 1, 0, 1},
            {0, 1, 1, 0}
        };
        
        int[,] graph2 = // 2
        {
            {0, 1, 0, 0},
            {1, 0, 0, 0},
            {0, 0, 0, 1},
            {0, 0, 1, 0}
        };
        
        int[,] graph3 = // 3
        {
            {0, 1, 0, 0, 0},
            {1, 0, 0, 0, 0},
            {0, 0, 0, 1, 0},
            {0, 0, 1, 0, 0},
            {0, 0, 0, 0, 0}
        };
        
        int[,] graph4 = // 4
        {
            {0, 0, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        };
        
        int[,] graph5 = // 1
        {
            {0, 1, 1, 1},
            {1, 0, 1, 1},
            {1, 1, 0, 1},
            {1, 1, 1, 0}
        };
        
        Console.WriteLine();
        
        AlgorithmOne algorithmOne = new AlgorithmOne();
        Console.WriteLine(algorithmOne.GetConnectivityComponentCount(graph5));
        
        Console.WriteLine();
        
        AlgorithmTwo algorithmTwo = new AlgorithmTwo();
        Console.WriteLine(algorithmTwo.GetConnectivityComponentCount(graph5));
    }
}