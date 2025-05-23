namespace Lab.EventLab.Track;

public class MainTrack
{
    public void Main(string[] args)
    {
        Track track = new Track(10, 200);
        
        SomeRunner someRunner1 = new SomeRunner(50, track.StartX, "SomeRunner10");
        SomeRunner someRunner2 = new SomeRunner(40, track.StartX, "SomeRunner2");
        SomeRunner someRunner3 = new SomeRunner(100, track.StartX, "SomeRunner3");

        List<SomeRunner> runners = new List<SomeRunner>();
        
        runners.Add(someRunner1);
        runners.Add(someRunner2);
        runners.Add(someRunner3);
        
        RunnerEvent runnerEvent = new RunnerEvent();
        Random random = new Random();
        
        while (IsRunnerFinished(runners, track) == null)
        {
            int time = random.Next(100);
            
            someRunner1.CurrentX += someRunner1.Speed / time;
            someRunner2.CurrentX += someRunner2.Speed / time;
            someRunner3.CurrentX += someRunner3.Speed / time;
        }
        
        runnerEvent.EventRunner += FinishEvent.DisplayMessage;
        runnerEvent.OnEvent(IsRunnerFinished(runners, track));
    }

    private static SomeRunner IsRunnerFinished(List<SomeRunner> runners, Track track)
    {
        foreach (var runner in runners)
        {
            if (runner.CurrentX > track.FinishX)
            {
                return runner;
            }        
        }
        
        return null;
    }
}
