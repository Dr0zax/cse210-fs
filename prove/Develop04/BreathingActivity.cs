using System.Diagnostics;

class BreathingActivity : Activity
{
    private int _interval = 5000;
    public BreathingActivity(string name, string description) : base(name, description)
    {

    }

    public void Activity()
    {
        Stopwatch stopwatch = new();

        DisplayWelcome();
        int time = getTime();

        Console.WriteLine();

        stopwatch.Start();

        while (stopwatch.Elapsed < TimeSpan.FromSeconds(time))
        {
            AnimationCounter("Breath In...", _interval, false);
            Console.WriteLine();
            AnimationCounter("Breath Out...", _interval, false);
            Console.WriteLine();
        }

        stopwatch.Stop();
        
        DisplayEnding();
    }
}