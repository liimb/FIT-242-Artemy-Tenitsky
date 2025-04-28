namespace Lab.linku;

public class Phone(string number, string name, string phoneOperator, int yearOfActivation)
{
    public string Number { get; } = number;
    public string FullName { get; } = name;
    public string PhoneOperator { get; } = phoneOperator;
    public int YearOfActivation { get; } = yearOfActivation;
}
