namespace DiscreteMath.TreeAlgorithm;

public class KraskalAlg
{
    public int GetTreeLength(int[,] graph)
    {
        int length = 0;
        
        List<Edge> edges = EdgeInitializator.GetEdges(graph);
        List<List<int>> vertexList = new();
        vertexList.Add([edges[0].V1, edges[0].V2]);
        vertexList.Add([edges[1].V1, edges[1].V2]);

        length += edges[0].Weight + edges[1].Weight;

        for (int i = 2; i < edges.Count; i++)
        {
            Edge edge = edges[i];
            List<int> vertex = new();
            int vertW = 0;
            int w = 0;
            int index = -1;

            for (int j = 0; j < vertexList.Count; j++)
            {
                foreach (var x1 in vertexList[j]) vertex.Add(x1);

                if (vertexList[j].Contains(edge.V1) && !vertexList[j].Contains(edge.V2))
                {
                    index = j;
                    vertW = edge.V2;
                    w = edge.Weight;
                }

                if (vertexList[j].Contains(edge.V2) && !vertexList[j].Contains(edge.V1))
                {
                    index = j;
                    vertW = edge.V1;
                    w = edge.Weight;
                }
            }

            if (index != -1)
            {
                vertexList[index].Add(vertW);
                length += w;
            }
            else
            {
                vertexList.Add([edge.V1, edge.V2]);
                length += w;
            }

            if (vertex.Count >= graph.GetLength(0)) break;
        }
        
        return length;
    }
}