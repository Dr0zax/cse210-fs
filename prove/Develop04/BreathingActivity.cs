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

        Console.WriteLine("\nGet ready...");
        AnimationSpinner("", 2000);

        stopwatch.Start();

        while (stopwatch.Elapsed < TimeSpan.FromSeconds(time))
        {
            AnimationCounter("Breath In...", _interval);
            Console.WriteLine();
            AnimationCounter("Breath Out...", _interval);
            Console.WriteLine();
        }

        stopwatch.Stop();
        
        DisplayEnding();
        AnimationSpinner("", _interval);
    }
}