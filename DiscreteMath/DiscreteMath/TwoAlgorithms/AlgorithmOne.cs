namespace DiscreteMath;

public class AlgorithmOne
{
    public int GetConnectivityComponentCount(int[,] graph)
    {
        List<int> unmarkedVertex = [];
        
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            unmarkedVertex.Add(i);
        }

        int count = 0;
        
        do
        {
            List<int> component = GetConnectedComponents(unmarkedVertex, graph);
            foreach (var v in component)
            {
                unmarkedVertex.Remove(v);
            }
            count++;
        } while (unmarkedVertex.Count > 0);

        
        return count;
    }

    private List<int> GetConnectedComponents(List<int> vertex, int[,] graph)
    {
        List<int> unmarkedVertex = [];

        unmarkedVertex.Add(vertex[0]);
        vertex.RemoveAt(0);

        for (int i = 0; i < unmarkedVertex.Count; i++)
        {
            for (int k = 0; k < vertex.Count; k++)
            {
                int v = vertex[k];

                if (graph[unmarkedVertex[i], v] == 1)
                {
                    unmarkedVertex.Add(v);
                    vertex.RemoveAt(k);
                    k--;
                }
            }
        }

        return unmarkedVertex;
    }
}