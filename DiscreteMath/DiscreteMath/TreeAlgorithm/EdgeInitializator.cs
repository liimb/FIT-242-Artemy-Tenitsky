namespace DiscreteMath.TreeAlgorithm;

public class EdgeInitializator
{
    public static List<Edge> GetEdges(int[,] graph, bool isDirected)
    {
        var edges = new List<Edge>();
        int a = 0;
        
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            for (int j = 0; j < graph.GetLength(1); j++)
            {
                if (graph[i, j] != 0 && i < j)
                {
                    if (isDirected || i < j)
                    {
                        Edge edge = new Edge(i, j, graph[i, j]);
                        edges.Add(edge);
                    }
                }
            }
        }
        
        edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        
        return edges;
    }
}