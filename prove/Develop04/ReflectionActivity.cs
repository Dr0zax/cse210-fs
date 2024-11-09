using System.Diagnostics;

class ReflectionActivity : Activity
{ 
    private int _interval = 10000;

    private List<string> _prompts = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ];

    private List<string> _questions = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];

    public ReflectionActivity(string name, string description) : base(name, description)
    {

    } 

    public void Activity()
    {
        Random random = new();
        Stopwatch stopwatch = new();
        DisplayWelcome();
        int time = getTime();
        
        Console.Clear();

        Console.WriteLine("Consider the following prompt:");

        Console.WriteLine(_prompts[random.Next(_prompts.Count)] + "\n");

        Console.WriteLine("When you are ready to continue press enter.");
        Console.ReadLine();

        Console.WriteLine("Now read each of the following questions and ponder them.");

        AnimationCounter("You may begin: ", 5000, true);

        Console.Clear();

        stopwatch.Start();

        while (stopwatch.Elapsed < TimeSpan.FromSeconds(time))
        {
            AnimationSpinner(_questions[random.Next(_questions.Count)] + " ", _interval);
        }

        stopwatch.Stop();

        DisplayEnding();
    }
}