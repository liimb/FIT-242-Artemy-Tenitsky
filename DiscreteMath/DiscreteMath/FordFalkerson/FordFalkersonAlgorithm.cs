namespace DiscreteMath.FordFalkerson;

public class FordFalkersonAlgorithm
{
    public static void Main(string[] args)
    {
        int[,] graph25 =
        {
            {int.MaxValue, 76, 47, int.MaxValue, int.MaxValue, 41}, // исток
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 44, 56},
            {int.MaxValue, int.MaxValue, int.MaxValue, 25, 15, int.MaxValue},
            {int.MaxValue, 35, int.MaxValue, int.MaxValue, 13, 29},
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 50},
            {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue} // сток
        };

        int length = graph25.GetLength(0);
        int maxFlow = 0;

        while (true)
        {
            List<int> path = new List<int> { 0 };
            bool[] visited = new bool[length];

            bool found = FindPath(graph25, path, visited, 0, length - 1);

            if (!found)
                break;

            int flow = GetMinFlowInPath(graph25, path);
            Console.WriteLine(flow);
            maxFlow += flow;

            BuildResidualGraph(graph25, path, flow);
        }

        Console.WriteLine($"Максимальный поток: {maxFlow}");
    }

    private static bool FindPath(int[,] graph, List<int> path, bool[] visited, int current, int target)
    {
        if (current == target)
            return true;

        visited[current] = true;

        int next;
        
        while ((next = GetMaxIndexInRow(graph, current, visited)) != -1)
        {
            path.Add(next);

            if (FindPath(graph, path, visited, next, target))
                return true;

            path.RemoveAt(path.Count - 1);
        }

        return false;
    }

    private static int GetMaxIndexInRow(int[,] graph, int index, bool[] visited)
    {
        int max = int.MinValue;
        int ind = -1;

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            if (!visited[i] && graph[index, i] != int.MaxValue && graph[index, i] > 0 && graph[index, i] > max)
            {
                max = graph[index, i];
                ind = i;
            }
        }

        return ind;
    }

    private static int GetMinFlowInPath(int[,] graph, List<int> path)
    {
        int min = int.MaxValue;

        for (int i = 0; i < path.Count - 1; i++)
        {
            int u = path[i];
            int v = path[i + 1];
            min = Math.Min(min, graph[u, v]);
        }

        return min;
    }

    private static void BuildResidualGraph(int[,] graph, List<int> path, int flow)
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            int u = path[i];
            int v = path[i + 1];
            
            graph[u, v] -= flow;
            
            graph[v, u] = 0;
            graph[v, u] += flow;
        }
    }
}
