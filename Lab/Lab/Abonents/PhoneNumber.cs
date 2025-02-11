namespace Labs.Abonent;

public class PhoneNumber(string phoneStr, string telecomOperator, int yearOfActivation)
{
    public string PhoneStr { get; set; } = phoneStr;
    public string TelecomOperator { get; set; } = telecomOperator;
    public int YearOfActivation { get; set; } = yearOfActivation;
}