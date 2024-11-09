using System.Diagnostics;

class ListingActivity : Activity
{
    private List<string> _prompts = [   
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];

    public ListingActivity(string name, string description) : base(name, description)
    {
        
    }

    public void Activity()
    {
        Random random = new();
        Stopwatch stopwatch = new();
        int itemsListed = 0;

        DisplayWelcome();
        int time = getTime();

        Console.Clear();

        Console.WriteLine("List as many answers as you can to this prompt:");
        Console.WriteLine(_prompts[random.Next(_prompts.Count)] + "\n");

        AnimationCounter("You may begin: ", 5000, true);

        stopwatch.Start();

        while (stopwatch.Elapsed < TimeSpan.FromSeconds(time))
        {
            Console.Write("> ");
            Console.ReadLine();
            itemsListed++;
        }

        Console.WriteLine($"You listed {itemsListed} item(s)!");

        stopwatch.Stop();

        DisplayEnding();
    }
}