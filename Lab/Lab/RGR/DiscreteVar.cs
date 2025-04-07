namespace Lab.RGR;

public class DiscreteVar
{
    public static void Main(string[] args)
    {
        string path = "/Users/artemiy/Repositories/Polikek/FIT-242-Artemy-Tenitsky/Lab/Lab/RGR/inputDis.txt";
        string[] input = File.ReadAllLines(path);
        
        int n = int.Parse(input[0]);
        
        int[,] graph = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] row = input[i + 1].Split(' ');
            
            for (int j = 0; j < n; j++)
            {
                graph[i, j] = int.Parse(row[j]);
            }
        }

        GetFordBellmanPaths(graph, 0);

    }
    
    public static int[] GetFordBellmanPaths(int[,] graph, int start)
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
        
        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                if (distance[j] > distance[i] + graph[i, j])
                {
                    Console.WriteLine("отриц вес");
                }
            }
        }

        return distance;
    }
    
    public static void PrintArray(int[,] array)
    {
        int rows = array.GetLength(0);

        Console.Write("    ");
        for (int j = 0; j < rows; j++)
            Console.Write($"{j,4} ");
        Console.WriteLine("\n   " + new string('-', rows * 5));

        for (int i = 0; i < rows; i++)
        {
            Console.Write($"{i} |");
            for (int j = 0; j < rows; j++)
            {
                Console.Write($"{array[i, j], 4} ");
            }
            Console.WriteLine();
        }
    }
}