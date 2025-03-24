namespace Lab.EventLab.Track;

public class FinishEvent
{
    public static void DisplayMessage(SomeRunner r) => Console.WriteLine($"бегун {r.Name} финишировал");

}
