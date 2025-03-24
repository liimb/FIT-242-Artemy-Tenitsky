namespace Labs.Abonent;

public class Abonent(string fullName, List<PhoneNumber> phones, string city)
{
    public string FullName{ get; set; } = fullName;
    public List<PhoneNumber> Phones { get; set; } = phones;
    public string City { get; set; } = city;
}
