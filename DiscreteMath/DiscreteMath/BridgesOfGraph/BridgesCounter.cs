using DiscreteMath.TreeAlgorithm;

namespace DiscreteMath.BridgesOfGraph;

public class BridgesCounter
{
    private AlgorithmOne _connectivityCounter = new();
    
    public void GetAllBridgesOfGraph(int[,] graph)
    {
        int connectivities = _connectivityCounter.GetConnectivityComponentCount(graph);
        List<Edge> bridges = new List<Edge>();
        
        Console.WriteLine($"Изначальное кол-во компонент: {connectivities}");

        int n = graph.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (graph[i, j] == 1)
                {
                    int[,] newGraph = (int[,])graph.Clone();
                    newGraph[i, j] = 0;
                    newGraph[j, i] = 0;
                    int newConnectivity = _connectivityCounter.GetConnectivityComponentCount(newGraph);

                    if (newConnectivity != connectivities)
                    {
                        bridges.Add(new Edge(i, j, 1));
                    }
                }
            }
        }

        if (bridges.Count == 0)
        {
            Console.WriteLine("Мостов нет");
        }
        else
        {
            Console.WriteLine("Все грани, являющиеся мостами:");
            foreach (var edge in bridges)
            {
                Console.WriteLine($"({edge.V1}, {edge.V2})");
            }
        }
    }
}