namespace Lab.RGR;

public class Square
{
    private void Main()
    {
        string path = "/Users/artemiy/Repositories/Polikek/FIT-242-Artemy-Tenitsky/Lab/Lab/RGR/SquareTests/input_s1_16.txt";
        string[] input = File.ReadAllLines(path);
        
        string[] nm = input[0].Split();
        int width = int.Parse(nm[0]);
        int height = int.Parse(nm[1]);
        
        int points = int.Parse(input[1]);

        bool[,] blocked = new bool[width + 1, height + 1];

        for (int i = 0; i < points; i++)
        {
            string[] xy = input[2 + i].Split();
            int X = int.Parse(xy[0]);
            int Y = int.Parse(xy[1]);
            blocked[X, Y] = true;
        }

        int[,] up = new int[width + 2, height + 2];
        for (int x = 1; x <= width; x++)
        {
            for (int y = 1; y <= height; y++)
            {
                if (!blocked[x, y])
                {
                    up[x, y] = up[x, y - 1] + 1;
                }
            }
        }

        int maxArea = 0;
        for (int y = 1; y <= height; y++)
        {
            for (int x = 1; x <= width; x++)
            {
                if (up[x, y] == 0) continue;

                int minHeight = up[x, y];
                int size = 1;
                maxArea = Math.Max(maxArea, minHeight * size);

                for (int k = x - 1; k >= 1 && up[k, y] > 0; k--)
                {
                    minHeight = Math.Min(minHeight, up[k, y]);
                    size++;
                    maxArea = Math.Max(maxArea, minHeight * size);
                }
            }
        }

        string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string outputPath = Path.Combine(projectDir, "square.txt");

        using (StreamWriter output = new StreamWriter(outputPath))
        {
            output.Write(maxArea);
            output.Flush();
            output.Close();
        }
        
        Console.WriteLine(maxArea);
    }
}
