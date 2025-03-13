namespace DiscreteMath.TheShortestPath;

public class MainDekstra
{
    public void Main(string[] args)
    {
        int[,] graph =
        {
            { 0, 3, 45, 0, 58 },
            { 0, 0, 7, 5, 0 },
            { 9, 78, 0, 58, 36 },
            { 87, 0, 0, 0, 78 },
            { 0, 9, 4, 0, 0 }
        };
        
        Console.WriteLine(DekstraAlgorithm.GetShortestPath(graph, 0, 4)); // 46
    }
}