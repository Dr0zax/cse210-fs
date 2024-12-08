class Game
{
    private bool _running;

    public Game()
    {
        _running = true;
    }

    public void RunGame()
    {
        Menu();
        while (_running)
        {
            ProcessInput();
        }
    }

    private void ProcessInput()
    {
        try
        {
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    NewGame();
                    break;
                case 2:
                    break;
                case 3:
                    _running = false;
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
        catch (System.FormatException)
        {
            Console.WriteLine("Invalid");
        }
    }

    private void NewGame()
    {
        Console.Clear();

        RoomSystem roomSystem = new();
        Console.Write("What is your name? ");
        string playerName = Console.ReadLine();

        Player player = new(0, 1, 999, 1, 5, playerName);
        
        player.SetName(playerName);

        roomSystem.GenRooms(5);

        roomSystem.Dungeon(player);

        return;
    }

    private void Menu()
    {
        Console.WriteLine("MENU: ");
        Console.WriteLine("1. Start");
        Console.WriteLine("2. Load");
        Console.WriteLine("3. Quit");
        Console.Write("> ");
    }
}