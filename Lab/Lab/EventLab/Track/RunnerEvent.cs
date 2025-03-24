using Lab.EventLab.SquarePoint;

namespace Lab.EventLab.Track;

public delegate void RunnerDelegate(SomeRunner runner);

public class RunnerEvent
{
    public event RunnerDelegate EventRunner;
    
    public void OnEvent(SomeRunner runner)
    {
        if (EventRunner != null)
        {
            EventRunner(runner);
        }
    }
}
