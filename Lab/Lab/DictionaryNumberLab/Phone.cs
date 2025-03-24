namespace Lab.DictionaryNumberLab;

public class Phone
{
    public string Number { get; private set; }
    public string Operator { get; private set; }

    public Phone(string number, string operatorString)
    {
        Number = number;
        Operator = operatorString;
    }
}
