namespace Lab.RGR;

public class MineField
{
    public void Main(string[] args)
    {
        string input = "/Users/artemiy/Repositories/Politech/FIT-242-Artemy-Tenitsky/Lab/Lab/RGR/MineFieldTestsFiles/input_s1_06.txt";
        
        string[] lines = File.ReadAllLines(input);
        
        string[] size = lines[0].Split(' ');
        int width = int.Parse(size[0]);
        int height = int.Parse(size[1]);
        
        int[,] field = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            string[] row = lines[x + 1].Split(' ');
            
            for (int y = 0; y < height; y++)
            { 
               field[x, y] = int.Parse(row[y]);
            }
        }
        
        int[,] minPaths = new int[width, height];
        int[,] path = new int[width, height];
        
        for (int j = 0; j < height; j++)
        {
            minPaths[0, j] = field[0, j];
            path[0, j] = -1;
        }
        
        for (int i = 1; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int minPrev = int.MaxValue;
                int bestCol = -1;
                
                for (int k = Math.Max(0, j - 1); k <= Math.Min(height - 1, j + 1); k++)
                {
                    if (minPaths[i - 1, k] < minPrev)
                    {
                        minPrev = minPaths[i - 1, k];
                        bestCol = k;
                    }
                }
                
                minPaths[i, j] = minPrev + field[i, j];
                path[i, j] = bestCol;
            }
        }
        
        int minTotal = int.MaxValue;
        int lastCol = -1;
        for (int j = 0; j < height; j++)
        {
            if (minPaths[width - 1, j] < minTotal)
            {
                minTotal = minPaths[width - 1, j];
                lastCol = j;
            }
        }

        int[] result = new int[width];
        
        int currentCol = lastCol;
        
        for (int i = width - 1; i >= 0; i--)
        {
            result[i] = currentCol + 1;
            if (i > 0)
            {
                currentCol = path[i, currentCol];
            }
        }
        
        string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string outputPath = Path.Combine(projectDir, "mines.txt");

        using (StreamWriter output = new StreamWriter(outputPath))
        {
            for (int i = 0; i < width; i++)
            {
                Console.WriteLine(result[i]);
                output.WriteLine(result[i]);
            }
            output.Flush();
            output.Close();
        }
    }
}
