namespace DiscreteMath.BridgesOfGraph;

public class MainTest
{
    public void Main(string[] args)
    {
        int[,] graph = 
        {       //0  1  2  3  4  5  6
            /*0*/{0, 1, 0, 0, 0, 0, 1},
            /*1*/{1, 0, 1, 0, 0, 0, 1},
            /*2*/{0, 1, 0, 0, 0, 0, 0},
            /*3*/{0, 0, 0, 0, 1, 0, 0},
            /*4*/{0, 0, 0, 1, 0, 1, 0},
            /*5*/{0, 0, 0, 0, 1, 0, 1},
            /*6*/{1, 1, 0, 0, 0, 1, 0} //4 моста
        };
        
        int[,] graph1 = 
        {       //0  1  2  3  4  5  6
            /*0*/{0, 1, 0, 0, 0, 0, 1},
            /*1*/{1, 0, 1, 0, 0, 0, 1},
            /*2*/{0, 1, 0, 0, 0, 0, 0},
            /*3*/{0, 0, 0, 0, 1, 0, 0},
            /*4*/{0, 0, 0, 1, 0, 1, 0},
            /*5*/{0, 0, 0, 0, 1, 0, 0},
            /*6*/{1, 1, 0, 0, 0, 0, 0} //2 компоненты, 3 моста
        };
        
        int[,] graph2 = 
        {       //0  1  2  3  4  5  6
            /*0*/{0, 1, 0, 0, 0, 0, 1},
            /*1*/{1, 0, 1, 0, 0, 0, 1},
            /*2*/{0, 1, 0, 1, 0, 0, 0},
            /*3*/{0, 0, 1, 0, 1, 0, 0},
            /*4*/{0, 0, 0, 1, 0, 1, 0},
            /*5*/{0, 0, 0, 0, 1, 0, 1},
            /*6*/{1, 1, 0, 0, 0, 1, 0} //нет мостов
        };
        
        int[,] graph3 = 
        {       //0  1  2  3  4  5  6
            /*0*/{0, 1, 0, 0, 0, 0, 1},
            /*1*/{1, 0, 1, 1, 0, 0, 1},
            /*2*/{0, 1, 0, 0, 0, 0, 0},
            /*3*/{0, 1, 0, 0, 1, 0, 0},
            /*4*/{0, 0, 0, 1, 0, 1, 0},
            /*5*/{0, 0, 0, 0, 1, 0, 1},
            /*6*/{1, 1, 0, 0, 0, 1, 0} //1 мост
        };
        
        BridgesCounter counter = new BridgesCounter();
        
        Console.WriteLine();
        counter.GetAllBridgesOfGraph(graph);
        Console.WriteLine();
        counter.GetAllBridgesOfGraph(graph1);
        Console.WriteLine();
        counter.GetAllBridgesOfGraph(graph2);
        Console.WriteLine();
        counter.GetAllBridgesOfGraph(graph3);
        Console.WriteLine();
    }
}