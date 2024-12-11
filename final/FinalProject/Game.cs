using FinalProject.GameSystems;

class Game
{
    private bool _running;

    public Game()
    {
        _running = true;
    }

    public void RunGame()
    {
        while (_running)
        {
            Console.Clear();
            Menu();
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
        roomSystem.GenRooms(5);

        string playerName = DialogueSystem.InputBox("What is your name? ");

        Player player = new(0, 1, 999, 1, 5, playerName);

        Console.Clear();

        DialogueSystem.DialogueBox("Your journey begins. (Enter)");

        Console.Clear();

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