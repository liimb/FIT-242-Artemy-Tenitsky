namespace Lab.SwimmingPool;

public class SwimmingPool
{
    public void Main(string[] args)
    {
        List<Instructor> instructors = new()
        {
            new Instructor(1, "Иванов"),
            new Instructor(2, "Петров"),
            new Instructor(3, "Сидоров"),
        };

        List<Client> clients = new()
        {
            new Client(1, "Алексей"),
            new Client(2, "Мария"),
            new Client(3, "Дмитрий"),
        };

        List<Visit> visits = new()
        {
            new Visit(1, 1, new DateTime(2024, 4, 1), 60),
            new Visit(2, 1, new DateTime(2024, 4, 1), 45),
            new Visit(3, 2, new DateTime(2024, 4, 2), 30),
            new Visit(1, 2, new DateTime(2024, 4, 3), 90),
            new Visit(2, 3, new DateTime(2024, 4, 3), 60),
            new Visit(1, 1, new DateTime(2024, 4, 4), 120),
            new Visit(3, 2, new DateTime(2024, 4, 5), 50),
        };
        
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("\n0 - Выход\n1 - Сгруппировать посещения по датам\n2 - Сгруппировать посещения по тренерам\n3 - Клиент с наибольшим временем посещений\n4 - Выдать все даты посещений клиента");
            
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Console.WriteLine("");
                    break;
                case 1:
                    GroupByDate(visits, clients, instructors);
                    break;
                case 2:
                    GroupByTrainer(visits, clients, instructors);
                    break;
                case 3:
                    ClientWithMaxTime(visits, clients);
                    break;
                case 4:
                    ListClientVisits(visits, clients);
                    break;
            }
        }
    }
    
     private static void GroupByDate(List<Visit> visits, List<Client> clients, List<Instructor> trainers)
    {
        var grouped = visits.GroupBy(v => v.VisitDate);

        foreach (var group in grouped)
        {
            Console.WriteLine($"\nДата: {group.Key.ToShortDateString()}");
            foreach (var visit in group)
            {
                var client = clients.First(c => c.Id == visit.ClientId);
                var trainer = trainers.First(t => t.Id == visit.TrainerId);
                Console.WriteLine($"  Клиент: {client.Name}, Тренер: {trainer.Name}, Время: {visit.DurationMinutes} мин");
            }
        }
    }

    private static void GroupByTrainer(List<Visit> visits, List<Client> clients, List<Instructor> trainers)
    {
        var grouped = visits.GroupBy(v => v.TrainerId);

        foreach (var group in grouped)
        {
            var trainer = trainers.First(t => t.Id == group.Key);
            Console.WriteLine($"\nТренер: {trainer.Name}");
            foreach (var visit in group)
            {
                var client = clients.First(c => c.Id == visit.ClientId);
                Console.WriteLine($"  Клиент: {client.Name}, Дата: {visit.VisitDate.ToShortDateString()}, Время: {visit.DurationMinutes} мин");
            }
        }
    }

    private static void ClientWithMaxTime(List<Visit> visits, List<Client> clients)
    {
        var maxClient = visits
            .GroupBy(v => v.ClientId)
            .Select(g => new { ClientId = g.Key, TotalMinutes = g.Sum(v => v.DurationMinutes) })
            .FirstOrDefault();

        if (maxClient != null)
        {
            var client = clients.First(c => c.Id == maxClient.ClientId);
            Console.WriteLine($"Клиент с наибольшим временем: {client.Name}, всего {maxClient.TotalMinutes} минут");
        }
        else
        {
            Console.WriteLine("Нет данных о посещениях.");
        }
    }

    private static void ListClientVisits(List<Visit> visits, List<Client> clients)
    {
        foreach (var client in clients)
        {
            Console.WriteLine($"\nКлиент: {client.Name}");
            var clientVisits = visits.Where(v => v.ClientId == client.Id);

            foreach (var visit in clientVisits)
            {
                Console.WriteLine($"  Дата посещения: {visit.VisitDate.ToShortDateString()} ({visit.DurationMinutes} мин)");
            }
        }
    }
}
