namespace DiscreteMath;

public class AlgorithmTwo
{
    private const int _uncheckVertexMark = -100;

    public int GetConnectivityComponentCount(int[,] graph)
    {
        int n = graph.GetLength(0);
        List<int> vertexes = new List<int>();
        List<int> uncheckVertexes = new List<int>();

        for (int i = 0; i < n; i++)
        {
            vertexes.Add(i);
            uncheckVertexes.Add(_uncheckVertexMark);
        }

        int componentId = 0;

        for (int i = 0; i < n; i++)
        {
            if (uncheckVertexes[i] == _uncheckVertexMark)
            {
                componentId++;
                MarkComponent(graph, i, componentId, uncheckVertexes);
            }
        }

        HashSet<int> components = new HashSet<int>(uncheckVertexes);
        return components.Count;
    }

    private void MarkComponent(int[,] graph, int vertex, int componentId, List<int> uncheckVertexes)
    {
        uncheckVertexes[vertex] = componentId;

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            if (graph[vertex, i] == 1 && uncheckVertexes[i] == _uncheckVertexMark)
            {
                uncheckVertexes[i] = componentId;
                MarkComponent(graph, i, componentId, uncheckVertexes);
            }
        }
    }
}