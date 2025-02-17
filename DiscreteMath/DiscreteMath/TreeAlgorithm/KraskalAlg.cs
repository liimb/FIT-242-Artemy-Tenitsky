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

            for (int j = 0; j < vertexList.Count; j++)
            {
                if(!(vertexList[j].Contains(edge.V1))
                {
                    
                } 
                else if (vertexList[j].Contains(edge.V2))
                {
                    
                }
                for (int k = 0; k < vertexList[j].Count; k++)
                {
                    if(vertexList[j][kedge.V1)
                }
            }
        }
        
        return length;
    }
}