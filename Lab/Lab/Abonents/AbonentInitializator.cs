namespace Labs.Abonent;

public class AbonentInitializator
{
    public static void Main(string[] args)
    {
        bool work = true;
        
        List<Abonent> abonents = new List<Abonent>();
        
        while (work)
        {
            Console.WriteLine("\n0 - добавить абонента\n1 - поиск по городу\n2 - поиск по номеру телефона\n3 - поиск по оператору связи\n4 - поиск по году подключения\n5 - выход\n");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 0:
                    Console.WriteLine("введите ФИО, количество номеров, город через запятую");
                    string s = Console.ReadLine();
                    CreateAbonents(abonents, s);
                    break;
                case 1:
                    if (abonents.Count > 0)
                    {
                        Console.WriteLine("введите город");
                        string city = Console.ReadLine();
                        GetAbonentsByCity(abonents, city);
                    }
                    else
                    {
                        Console.WriteLine("абонентов нет");
                    }
                    break;
                
                case 2:
                    if (abonents.Count > 0)
                    {
                        Console.WriteLine("введите номер телефона");
                        string phone = Console.ReadLine();
                        GetAbonentsByPhoneNumber(abonents, phone);
                    }
                    else
                    {
                        Console.WriteLine("абонентов нет");
                    }
                    break;
                
                case 3:
                    if (abonents.Count > 0)
                    {
                        Console.WriteLine("введите оператора");
                        string telOperat = Console.ReadLine();
                        GetAbonentsByTelOperator(abonents, telOperat);
                    }
                    else
                    {
                        Console.WriteLine("абонентов нет");
                    }
                    break;
                    
                case 4:
                    if (abonents.Count > 0)
                    {
                        Console.WriteLine("введите год подключения");
                        int year = int.Parse(Console.ReadLine());
                        GetAbonentsByYearOfActivation(abonents, year);
                    }
                    else
                    {
                        Console.WriteLine("абонентов нет");
                    }
                    break;
                    
                case 5:
                    work = false;
                    break;
            }
        }
    }

    private static void GetAbonentsByTelOperator(List<Abonent> abonents, string telOperator)
    {
        foreach (var ab in abonents)
        {
            foreach (var phones in ab.Phones)
            {
                if (phones.TelecomOperator == telOperator)
                {
                    Console.WriteLine(ab.ToString());
                    break;
                }
            }
        }
    }
    
    private static void GetAbonentsByYearOfActivation(List<Abonent> abonents, int year)
    {
        foreach (var ab in abonents)
        {
            foreach (var phones in ab.Phones)
            {
                if (phones.YearOfActivation == year)
                {
                    Console.WriteLine(ab.ToString());
                    break;
                }
            }
        }
    }
    
    private static void GetAbonentsByPhoneNumber(List<Abonent> abonents, string number)
    {
        foreach (var ab in abonents)
        {
            foreach (var phones in ab.Phones)
            {
                if (phones.PhoneStr == number)
                {
                    Console.WriteLine(ab.ToString());
                    break;
                }
            }
        }
    }
    
    private static void GetAbonentsByCity(List<Abonent> abonents, string city)
    {
        foreach (var ab in abonents)
        {
            if (ab.City == city)
            {
                Console.WriteLine(ab.ToString());
            }
        }
    }
    
    private static void CreateAbonents(List<Abonent> abonents, string input)
    {
        string[] inputs = input.Split(",");
        List<PhoneNumber> numbers = new List<PhoneNumber>();
        
        for (int i = 0; i < int.Parse(inputs[1]); i++)
        {
            Console.WriteLine("введите номер телефона, оператора и год активации через пробел");
            string s = Console.ReadLine();
            string[] number = s.Split(" ");
            numbers.Add(new PhoneNumber(number[0],number[1], int.Parse(number[2])));
        }
        
        abonents.Add(new Abonent(inputs[0], numbers, inputs[2]));
    }
}