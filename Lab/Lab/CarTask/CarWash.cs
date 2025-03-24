namespace Lab.CarTask;

public class CarWash
{
    public void Wash(Car car)
    {
        if (car.IsClean)
        {
            Console.WriteLine($"машина {car.Year} года чистая");
            return;
        }
        
        car.IsClean = true;
        Console.WriteLine($"машина {car.Year} года помыта");
    }
}
