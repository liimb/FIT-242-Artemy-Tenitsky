namespace DiscreteMath.FordBellman;

public class BellmanAlg
{
    public static void Main(string[] args)
    {
        int[,] graph = {
            { 0, 1, 0, 0, 3 },
            { 0, 0, 8, 7, 1 },
            { 0, 0, 0, 1,-5 },
            { 0, 0, 2, 0, 0 },
            { 0, 0, 0, 4, 0 }
        };

        int[] dis = GetBellmanPaths(graph, 2);

        foreach (var a in dis)
        {
            Console.WriteLine(a);
        }
    }
    
    public static int[] GetBellmanPaths(int[,] graph, int start)
    {
        int verticesCount = graph.GetLength(0);
        int[] distance = new int[verticesCount];

        for (int i = 0; i < verticesCount; i++)
        {
            distance[i] = int.MaxValue;
        }

        distance[start] = 0;

        for (int k = 0; k < verticesCount - 1; k++)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (graph[i, j] != 0 && distance[i] != int.MaxValue &&
                        distance[i] + graph[i, j] < distance[j])
                    {
                        distance[j] = distance[i] + graph[i, j];
                    }
                }
            }
        }

        return distance;
    }
}