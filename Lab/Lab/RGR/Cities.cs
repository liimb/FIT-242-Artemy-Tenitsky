namespace Lab.RGR;

public class Cities
{
    private void Main()
    {
        string input = "fullPath/input_s1_01.txt";
        
        string[] lines = File.ReadAllLines(input);
        
        string[] firstLine = lines[0].Split();
        int cities = int.Parse(firstLine[0]);
        int roads = int.Parse(firstLine[1]);

        int[,] dist = new int[cities + 1, cities + 1];

        for (int i = 1; i <= cities; i++)
        {
            for (int j = 1; j <= cities; j++)
            {
                dist[i, j] = (i == j) ? 0 : int.MaxValue;
            }
        }

        for (int k = 1; k <= roads; k++)
        {
            string[] parts = lines[k].Split();
            int i = int.Parse(parts[0]);
            int j = int.Parse(parts[1]);
            int L = int.Parse(parts[2]);

            if (L < dist[i, j])
            {
                dist[i, j] = L;
                dist[j, i] = L;
            }
        }

        for (int k = 1; k <= cities; k++)
        {
            for (int i = 1; i <= cities; i++)
            {
                for (int j = 1; j <= cities; j++)
                {
                    if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue)
                    {
                        dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                    }
                }
            }
        }

        int maxDist = 0;
        for (int i = 1; i <= cities; i++)
        {
            for (int j = i + 1; j <= cities; j++)
            {
                if (dist[i, j] > maxDist)
                {
                    maxDist = dist[i, j];
                }
            }
        }
        
        string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string outputPath = Path.Combine(projectDir, "cities.txt");

        using (StreamWriter output = new StreamWriter(outputPath))
        {
            output.Write(maxDist);
            output.Flush();
            output.Close();
        }
        
        Console.WriteLine(maxDist);
    }
}
