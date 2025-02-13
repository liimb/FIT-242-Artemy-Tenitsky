namespace DiscreteMath;

public class AlgorithmTwo
{
    private const int _uncheckVertexMark = -100;
    
    public int GetConnectivityComponentCount(int[,] graph)
    {
        List<int> vertexes = [];
        List<int> uncheckVertexes = [];
        
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            vertexes.Add(i);
            uncheckVertexes.Add(_uncheckVertexMark);
        }

        uncheckVertexes[0] = 1;
        
        for (int i = 0; i < vertexes.Count; i++)
        {
            int currentVertex;
            if (uncheckVertexes[i] == _uncheckVertexMark)
            {
                currentVertex = GetMaxFromIntList(uncheckVertexes) + 1;
            }
            else
            {
                currentVertex = uncheckVertexes[i];
            }

            List<int> neighbors = GetConnectivityVertexes(graph, i);

            if (neighbors.Count == 0)
            {
                uncheckVertexes[i] = currentVertex;
            }
            
            foreach (var ver in neighbors)
            {
                uncheckVertexes[ver] = currentVertex;
            }
        }
        
        HashSet<int> components = new HashSet<int>(uncheckVertexes);

        return components.Count;
    }

    private int GetMaxFromIntList(List<int> intList)
    {
        int max = intList[0];

        foreach (int num in intList)
        {
            if (num > max)
            {
                max = num;
            }
        }
        
        return max;
    }

    private List<int> GetConnectivityVertexes(int[,] graph, int vertex)
    {
        List<int> vertexes = new List<int>();

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            if (graph[vertex, i] == 1)
            {
                vertexes.Add(i);
            }
        }
        
        return vertexes;
    }
}