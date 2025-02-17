namespace DiscreteMath.TreeAlgorithm;

public class PrimaAlg
{
    public int GetTreeLength(int[,] graph)
    {
        int length = 0;
        List<int> vertexes = new();
        List<Edge> edges = new();

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            vertexes.Add(i);
        }

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            for (int j = 0; j < graph.GetLength(1); j++)
            {
                edges.Add(new Edge(i, j, graph[i, j]));
            }
        }
        
        return length;
    }
}