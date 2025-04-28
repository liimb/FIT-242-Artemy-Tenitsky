namespace Lab.linku;

public class LinkuMain
{
    public void Main(string[] args)
    {
        List<Phone> phones =
        [
            new Phone("123456789", "Aleks", "Mts", 2003),
            new Phone("758365748", "John", "B", 2004),
            new Phone("857265859", "N1", "Mts", 2003),
            new Phone("757284756", "N2", "t2", 2005),
            new Phone("747284957", "N3", "t2", 2004),
            new Phone("827465738", "N4", "t2", 2005),
            new Phone("857428484", "N5", "B", 2004),
            new Phone("847274758", "N6", "B", 2003),
            new Phone("727357384", "N7", "t2", 2007),
            new Phone("572736575", "N8", "yota", 2008),
            new Phone("823746573", "N9", "yota", 2009),
            new Phone("823755375", "N10", "B", 2010),
            new Phone("757238573", "N11", "B", 2002),
            new Phone("857347723", "N12", "Mts", 2005),
            new Phone("282847572", "N13", "Mts", 2003),
            new Phone("754728475", "N14", "Mts", 2003),
        ];
        
        bool search = true;

        int a = -1;
        
        while (a != 0)
        {
            Console.WriteLine("\n0 - выход\n1 - сгруппировать по году\n2 - сгруппировать по оператору\n3 - выдать телефон по имени\n");
            a = int.Parse(Console.ReadLine());
            
            switch (a)
            {
                case 0:
                    Console.WriteLine("конец");
                    a = 0;
                    break;
                case 1:
                    YearSorter(phones);
                    break;
                case 2:
                    OperatorSorter(phones);
                    break;
                
                case 3:
                    Console.WriteLine("введите имя");
                    string name = Console.ReadLine();
                    GetByName(phones, name);
                    break;
            }
        }
    }

    private static void YearSorter(List<Phone> phones)
    {
        var groupedByYear = phones
            .GroupBy(p => p.YearOfActivation);

        foreach (var group in groupedByYear)
        {
            Console.WriteLine($"год: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  номер: {phone.Number}, имя: {phone.FullName}, оператор: {phone.PhoneOperator}");
            }
        }
    }
    
    private static void OperatorSorter(List<Phone> phones)
    {
        var groupedByOperator = phones
            .GroupBy(p => p.PhoneOperator);

        foreach (var group in groupedByOperator)
        {
            Console.WriteLine($"оператор: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  номер: {phone.Number}, имя: {phone.FullName}, год: {phone.YearOfActivation}");
            }
        }
    }

    private static void GetByName(List<Phone> phones, string name)
    {
        Phone phone = phones.FirstOrDefault(p => p.FullName == name);
        if (phone != null)
        {
            Console.WriteLine($"  номер: {phone.Number}, имя: {phone.FullName}, год: {phone.YearOfActivation}, оператор: {phone.PhoneOperator}");
        }
        else
        {
            Console.WriteLine("с таким именем телефон не найден");   
        }
    }
}
