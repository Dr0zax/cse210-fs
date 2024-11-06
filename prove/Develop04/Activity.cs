class Activity
{
    private int _time;
    private string _name;
    private string _description;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayWelcome()
    {
        Console.WriteLine($"Welcome to the {_name}\n");
        Console.WriteLine($"{_description}\n");

        Console.Write("How long, in seconds, would you like for your session? ");
        _time = int.Parse(Console.ReadLine());
    }

    public void DisplayEnding()
    {
        Console.WriteLine("Well done!\n");
        Console.WriteLine($"You have completed another {_time} seconds of the {_name}");
    }

    public void AnimationCounter(string baseMessage, int interval)
    {
        Console.Write($"{baseMessage}");
        for (int i = 1; i <= (interval / 1000); i++)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public void AnimationSpinner(string baseMessage, int interval)
    {
        List<string> frames = [
            "|",
            "/",
            "-",
            "\\"
        ];

        Console.Write($"{baseMessage}");

        for (int i = 0; i < (interval / 1000); i++)
        {
            for (int frame = 0; frame < frames.Count; frame++)
            {
                Console.Write(frames[frame]);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }

        Console.WriteLine();
    }

    public int getTime()
    {
        return _time;
    }

    public void setTime(int time)
    {
        _time = time;
    }
}