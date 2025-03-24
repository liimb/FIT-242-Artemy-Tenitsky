namespace Lab.CarTask;

public class Car(int year, string brand, bool isClean)
{
    public int Year { get; set; } = year;
    public string Brand { get; set; } = brand;
    public bool IsClean { get; set; } = isClean;
}
