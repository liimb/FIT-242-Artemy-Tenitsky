namespace Lab.RGR;

public class DiscreteVar
{
    public void Main(string[] args)
    {
        string path = "/Users/artemiy/Repositories/Politech/FIT-242-Artemy-Tenitsky/Lab/Lab/RGR/inputDis.txt";
        string[] input = File.ReadAllLines(path);
        
        string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string outputPath = Path.Combine(projectDir, "discr.txt");
        
        int n = int.Parse(input[0]);
        
        int[,] graph = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] row = input[i + 1].Split(' ');
            
            for (int j = 0; j < n; j++)
            {
                if (int.Parse(row[j]) == 0 && i != j)
                {
                    graph[i, j] = int.MaxValue;
                }
                else
                {
                    graph[i, j] = int.Parse(row[j]);
                }
            }
        }

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graph[i, k] != int.MaxValue && graph[k, j] != int.MaxValue &&
                        graph[i, k] + graph[k, j] < graph[i, j])
                    {
                        graph[i, j] = graph[i, k] + graph[k, j];
                    }
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (graph[i, i] < 0)
            {
                using (StreamWriter output = new StreamWriter(outputPath))
                {
                    output.Write("-1");
                    output.Flush();
                    output.Close();
                }
                Console.WriteLine("-1");
                return;
            }
        }

        int minPath = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i != j && graph[i, j] < minPath)
                {
                    minPath = graph[i, j];
                }
            }
        }
        
        using (StreamWriter output = new StreamWriter(outputPath))
        {
            output.Write(minPath);
            output.Flush();
            output.Close();
        }
        Console.WriteLine(minPath);
    }
}
