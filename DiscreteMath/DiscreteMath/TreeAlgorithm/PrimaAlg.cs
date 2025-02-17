namespace DiscreteMath.TreeAlgorithm;

public class PrimaAlg
{
    public int GetTreeLength(int[,] graph)
    {
        int length = 0;
        List<int> vertexes = new();
        List<int> secVert = new();
        List<Edge> edges = EdgeInitializator.GetEdges(graph);

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            vertexes.Add(i);
        }
        
        secVert.Add(vertexes[0]);
        vertexes.RemoveAt(0);
        
        
        while (vertexes.Count > 0)
        {
            Edge minEdge = null;
            int minWeight = int.MaxValue;

            foreach (var edge in edges)
            {
                if ((secVert.Contains(edge.V1) && vertexes.Contains(edge.V2)) ||
                    (secVert.Contains(edge.V2) && vertexes.Contains(edge.V1)))
                {
                    if (edge.Weight < minWeight)
                    {
                        minWeight = edge.Weight;
                        minEdge = edge;
                    }
                }
            }

            if (minEdge != null)
            {
                length += minWeight;

                if (vertexes.Contains(minEdge.V1))
                {
                    secVert.Add(minEdge.V1);
                    vertexes.Remove(minEdge.V1);
                }
                else if (vertexes.Contains(minEdge.V2))
                {
                    secVert.Add(minEdge.V2);
                    vertexes.Remove(minEdge.V2);
                }
            }
        }
        
        return length;
    }
}