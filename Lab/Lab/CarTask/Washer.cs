namespace Lab.CarTask;

public class Washer
{
    delegate void CarWasher(Car car);
    
    public void Main(string[] args)
    {
        Garage garage = new Garage(new List<Car>()
        {
            new Car(1653, "Gf", true),
            new Car(1234, "dfg", false),
            new Car(3463, "dfv", true),
            new Car(3562, "rtgs", false),
            new Car(3456, "yhds", true),
            new Car(2345, "hntd", false),
        });
        
        CarWash washer = new CarWash();

        CarWasher carWasher = washer.Wash;
        
        foreach (var car in garage.Cars)
        {
            carWasher(car);
        }
    }
}