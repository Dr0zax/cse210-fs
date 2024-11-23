class Program
{
    static void Menu()
    {
        List<string> menu = [
            "1. Create new goal",
            "2. List goals",
            "3. Save goals",
            "4. Load goals",
            "5. Record Event",
            "6. Quit",
        ];

        Console.WriteLine("\nMenu Options:");

        foreach (string item in menu)
        {
            Console.WriteLine(item);
        }
    }

    static void Main(string[] args)
    {
        List<Goal> goals = new();

        bool running = true;
        LevelSystem levelSystem = new();
    
        Console.Clear();
        while (running)
        {
            levelSystem.GenerateLevelBar();
            Menu();

            Console.Write("> ");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("The types of goals are:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    
                    Console.Write("> ");
                    input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            Goal simpleGoal = new SimpleGoal();
                            goals.Add(simpleGoal);
                            break;
                        case 2:
                            Goal eternalGoal = new EternalGoal();
                            goals.Add(eternalGoal);
                            break;
                        case 3:
                            Goal checklistGoal = new ChecklistGoal();
                            goals.Add(checklistGoal);
                            break;
                        default:
                            break;
                    }

                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Your goals:");
                    foreach (Goal goal in goals)
                    {
                        string state = " ";
                        if (goal.GetComplete() == true) { state = "X"; }
                        if (goal is ChecklistGoal cGoal)
                        {
                            Console.WriteLine($"{goals.IndexOf(goal) + 1}. [{state}] {goal.getName()} ({goal.getDescription()}) -- Currently Completed {cGoal.GetTimesCompleted()}/{cGoal.GetRequirement()}");
                        }
                        else
                        {
                            Console.WriteLine($"{goals.IndexOf(goal) + 1}. [{state}] {goal.getName()} ({goal.getDescription()})");
                        }
                    }
                    Console.WriteLine();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Your goals:");
                    foreach (Goal goal in goals)
                    {
                        Console.WriteLine($"{goals.IndexOf(goal) + 1}. {goal.getName()} ({goal.getDescription()})");
                    }
                    Console.Write("Which goal did your complete? ");
                    
                    int choice = int.Parse(Console.ReadLine());
                    int value = goals[choice-1].Complete();
                    levelSystem.AddXP(value);
                    Console.Clear();
                    Console.WriteLine($"Your earned {value} points.");
                    Console.WriteLine();
                    break;
                case 6:
                    running = false;
                    break;
            }
        }

    }
}