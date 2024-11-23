class Program
{
    static List<string> menu = [
        "Menu Options:",
        "1. Create new goal",
        "2. List goals",
        "3. Save goals",
        "4. Load goals",
        "5. Record Event",
        "6. Quit\n",
    ];

    static List<string> subMenu = [
        "The types of goals are:",
        "1. Simple Goal",
        "2. Eternal Goal",
        "3. Checklist Goal\n"
    ];

    static void DisplayMenu(List<string> menu)
    {
        foreach (string item in menu)
        {
            Console.WriteLine(item);
        }
    }

    static void Main(string[] args)
    {
        List<Goal> goals = new();
        LevelSystem levelSystem = new();
        FileSystem fileSystem = new();
    
        Console.Clear();

        bool running = true;
        while (running)
        {
            levelSystem.GenerateLevelBar();
        
            DisplayMenu(menu);

            Console.Write("> ");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    DisplayMenu(subMenu);
                    
                    Console.Write("> ");
                    input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            Goal simpleGoal = new SimpleGoal("simple");
                            goals.Add(simpleGoal);
                            break;
                        case 2:
                            Goal eternalGoal = new EternalGoal("eternal");
                            goals.Add(eternalGoal);
                            break;
                        case 3:
                            Goal checklistGoal = new ChecklistGoal("checklist");
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
                        if (goal.GetCompleted() == true) { state = "X"; }
                        Console.WriteLine($"{goals.IndexOf(goal) + 1}. [{state}] {goal}");   
                    }
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("What shall the name of the file be? ");
                    string fileName = Console.ReadLine();
                    fileSystem.SaveFile(fileName, levelSystem, goals);
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("This will clear all your current goals, continue? (y/n) ");
                    string choice = Console.ReadLine();

                    if (choice == "y")
                    {
                        Console.Clear();
                        goals.Clear();
                        Console.Write("Which file would you like to load? ");
                        string fileToLoad = Console.ReadLine();
                        fileSystem.LoadFile(fileToLoad, levelSystem, goals);
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 5:
                    Console.Clear();
                    Console.WriteLine("Your goals:");
                    foreach (Goal goal in goals)
                    {
                        Console.WriteLine(goal);
                    }

                    Console.Write("Which goal did your complete? ");
                    
                    int choice2 = int.Parse(Console.ReadLine());
                    int value = goals[choice2-1].Complete();

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