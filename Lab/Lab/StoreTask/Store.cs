namespace Lab.StoreTask;

public class Store
{
    public static List<Product> Products { get; set; } = new();
    public static List<Provider> Providers { get; set; } = new();
    public static List<ProductMovement> Movements { get; set; } = new();
    
    public static void Main(string[] args)
    {
        Product product1 = new Product(1, "Ноутбук");
        Product product2 = new Product(2, "Монитор");

        Provider provider1 = new Provider(1, "Поставщик A");
        Provider provider2 = new Provider(2, "Поставщик B");

        ProductMovement pm1 = new ProductMovement
        (
            product1.Id,
            provider1.Id, 
            10,
           true, 
            50000,
            "2025:5:1"
        );

        ProductMovement pm2 = new ProductMovement
        (
            product2.Id,
            provider2.Id,
            5,
            true,
            15000,
            "2025:5:1"
        );

        ProductMovement pm3 = new ProductMovement
        (
            product1.Id,
            provider2.Id,
            5,
            true,
            48000,
            "2025:5:3"
        );

        ProductMovement pm4 = new ProductMovement
        (
            product1.Id,
            -1,
            8,
            false,
            100000,
            "2025:5:4"
        );

        ProductMovement pm5 = new ProductMovement
        (
            product2.Id,
            -1,
            5,
            false,
            100000,
            "2025:5:5"
        );
        
        Products.Add(product1);
        Products.Add(product2);
        
        Providers.Add(provider1);
        Providers.Add(provider2);
        
        Movements.Add(pm1);
        Movements.Add(pm2);
        Movements.Add(pm3);
        Movements.Add(pm4);
        Movements.Add(pm5);
        
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("\n0 - Выход\n1 - Сгруппировать выдачи по датам\n2 - Сгруппировать по поставщику и отсортировать по дате\n3 - список товаров на складе\n4 - общая сумма выданных товаров\n5 - прибыль склада");
            
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Console.WriteLine("");
                    break;
                case 1:
                    GetIncomingByDate();
                    break;
                case 2:
                    GetProvidersByDate();
                    break;
                case 3:
                    GetAllProducts();
                    break;
                case 4:
                    GetAllIncomingSum();
                    break;
                case 5:
                    GetAllIncome();
                    break;
            }
        }
    }
    
    public static void GetIncomingByDate()
    {
        var grouped = Movements
            .Where(m => m.IsIncoming)
            .GroupBy(m => m.Date);

        Console.WriteLine("Поступления, сгруппированные по дате:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"Дата: {group.Key}");
            foreach (var m in group)
            {
                Console.WriteLine($"  Товар: {m.ProductId}, Кол-во: {m.Quantity}, Цена: {m.PricePerUnit}");
            }
        }
    }
    
    public static void GetProvidersByDate()
    {
        var grouped = Movements
            .Where(m => m.IsIncoming && m.ProviderId != -1)
            .GroupBy(m => m.ProviderId);

        Console.WriteLine("Поступления, сгруппированные по поставщикам и дате:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"Дата: {group.Key}");
            foreach (var m in group)
            {
                Console.WriteLine($"Поставщик: {m.ProviderId}, Товар: {m.ProductId}");
            }
        }
    }
    
    public static void GetAllProducts()
    {
        Console.WriteLine("Остатки на складе:");
        foreach (var product in Products)
        {
            int incoming = Movements.Where(m => m.ProductId == product.Id && m.IsIncoming).Sum(m => m.Quantity);
            int outgoing = Movements.Where(m => m.ProductId == product.Id && !m.IsIncoming).Sum(m => m.Quantity);
            int stock = incoming - outgoing;

            if (stock > 0)
            {
                Console.WriteLine($"{product.Name}: {stock} штук");
            }
        }
    }
    
    public static void GetAllIncomingSum()
    {
        var total = Movements
            .Where(m => !m.IsIncoming)
            .Sum(m => m.Quantity * m.PricePerUnit);
        Console.WriteLine($"сумма выданного товара: {total}");
    }
    
    public static void GetAllIncome()
    {
        decimal profit = 0;

        var productGroups = Movements
            .GroupBy(m => m.ProductId);

        foreach (var group in productGroups)
        {
            var incoming = group.Where(m => m.IsIncoming).ToList();
            var outgoing = group.Where(m => !m.IsIncoming).ToList();

            decimal totalIncomingCost = incoming.Sum(m => m.Quantity * m.PricePerUnit);
            decimal totalOutgoingRevenue = outgoing.Sum(m => m.Quantity * m.PricePerUnit);

            profit += totalOutgoingRevenue - totalIncomingCost;
        }

        Console.WriteLine($"прибыль склада: {profit} руб.");
    }
}
