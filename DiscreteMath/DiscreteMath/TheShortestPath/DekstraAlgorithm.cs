using DiscreteMath.TreeAlgorithm;

namespace DiscreteMath.TheShortestPath;

public class DekstraAlgorithm
{
    public static int GetShortestPath(int[,] graph, int from, int to)
    {
        int verticesCount = graph.GetLength(0);
        int[] distances = new int[verticesCount];
        bool[] visited = new bool[verticesCount];
        int currentVertex = from;

        for (int i = 0; i < verticesCount; i++)
        {
            distances[i] = int.MaxValue;
        }

        distances[from] = 0;

        for (int i = 0; i < verticesCount; i++)
        {
            int minDistance = int.MaxValue;

            for (int j = 0; j < verticesCount; j++)
            {
                if (!visited[j] && distances[j] < minDistance)
                {
                    minDistance = distances[j];
                    currentVertex = j;
                }
            }

            for (int j = 0; j < verticesCount; j++)
            {
                if (!visited[j] && graph[currentVertex, j] > 0)
                {
                    int newDistance = distances[currentVertex] + graph[currentVertex, j];
                    if (newDistance < distances[j])
                    {
                        distances[j] = newDistance;
                    }
                }
            }
            
            visited[currentVertex] = true;
        }
        
        return distances[to];
    }
}