namespace DiscreteMath.Little;

public class LittleAlg
{
    public void Main(string[] args)
    {
        int[,] graph = 
        {
            { int.MaxValue, 6, 4, 8, 27, 14 },
            { 26, int.MaxValue, 7, 41, 27, 16 },
            { 42, 7, int.MaxValue, 4, 3, 19 },
            { 8, 11, 34, int.MaxValue, 44, 11 },
            { 17, 53, 23, 5, int.MaxValue, 7 },
            { 14, 10, 19, 41, 51, int.MaxValue },
        };
        
        Console.WriteLine(GetKomLength(graph));
    }

    public static int GetKomLength(int[,] graph)
    {
        int[,] matrix = (int[,])graph.Clone();
        int n = matrix.GetLength(0);
        int lowerBound = 0;

        while (n > 2)
        {
            lowerBound += ReduceMatrix(matrix);

            (int row, int col) = SelectBestZero(matrix);
            
            matrix = RemoveRowAndColumn(matrix, row, col);

            matrix[col, row] = int.MaxValue;
            
            n--;
        }
        
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (matrix[i, j] != int.MaxValue)
                {
                    lowerBound += matrix[i, j];
                }
            }
        }

        return lowerBound;
    }

    private static int ReduceMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int reduction = 0;

        for (int i = 0; i < n; i++)
        {
            int min = int.MaxValue;
            for (int j = 0; j < n; j++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];

            if (min != int.MaxValue && min > 0)
            {
                for (int j = 0; j < n; j++)
                    if (matrix[i, j] != int.MaxValue)
                        matrix[i, j] -= min;
                reduction += min;
            }
        }

        for (int j = 0; j < n; j++)
        {
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];

            if (min != int.MaxValue && min > 0)
            {
                for (int i = 0; i < n; i++)
                    if (matrix[i, j] != int.MaxValue)
                        matrix[i, j] -= min;
                reduction += min;
            }
        }

        return reduction;
    }

    private static (int, int) SelectBestZero(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int bestZero = -1, bestRow = -1, bestCol = -1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == 0)
                {
                    int rowMin = int.MaxValue;
                    int colMin = int.MaxValue;

                    for (int k = 0; k < n; k++)
                        if (k != j && matrix[i, k] < rowMin)
                            rowMin = matrix[i, k];

                    for (int k = 0; k < n; k++)
                        if (k != i && matrix[k, j] < colMin)
                            colMin = matrix[k, j];

                    int zero = (rowMin == int.MaxValue ? 0 : rowMin) + (colMin == int.MaxValue ? 0 : colMin);

                    if (zero > bestZero)
                    {
                        bestZero = zero;
                        bestRow = i;
                        bestCol = j;
                    }
                }
            }
        }

        return (bestRow, bestCol);
    }

    private static int[,] RemoveRowAndColumn(int[,] matrix, int rowToRemove, int colToRemove)
    {
        int n = matrix.GetLength(0);
        int[,] result = new int[n-1, n-1];

        for (int i = 0, newI = 0; i < n; i++)
        {
            if (i == rowToRemove) continue;
            for (int j = 0, newJ = 0; j < n; j++)
            {
                if (j == colToRemove) continue;
                result[newI, newJ++] = matrix[i, j];
            }
            newI++;
        }
        
        return result;
    }
}