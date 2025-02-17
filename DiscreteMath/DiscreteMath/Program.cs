using DiscreteMath.TreeAlgorithm;

namespace DiscreteMath;

public static class Program
{
    private static void Main(string[] args)
    {
        int[,] graph1 =
        {
            {0, 9, 0, 0, 0, 4, 9},
            {9, 0, 0, 0, 2, 0, 0},
            {0, 0, 0, 8, 7, 0, 0},
            {0, 0, 8, 0, 15, 1, 0},
            {0, 2, 7, 15, 0, 0, 6},
            {4, 0, 0, 1, 0, 0, 0},
            {9, 0, 0, 0, 6, 0, 0}
        };

        Console.WriteLine();
        
        PrimaAlg primaAlg = new PrimaAlg();
        Console.WriteLine(primaAlg.GetTreeLength(graph1));
        
        Console.WriteLine();
        
        KraskalAlg kraskalAlg = new KraskalAlg();
        Console.WriteLine(kraskalAlg.GetTreeLength(graph1));
    }
}