using FinalProject.GameSystems;

class Game
{
    private bool _running;
    private Player player;

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
        int menuChoice = 0;

        try
        {
            menuChoice = int.Parse(DialogueSystem.InputBox(""));
        }
        catch (System.FormatException)
        {
            DialogueSystem.DialogueBox("Invalid Option");
        }

        switch (menuChoice)
        {
            case 1:
                StartGame(new(0, 1, 25, 5, 5, ""), true);
                break;
            case 2:
                if (player != null)
                {
                    StartGame(player, false);
                }
                else 
                {
                    DialogueSystem.DialogueBox("No current save data.");
                }
                break;
            case 3:
                string fileName = DialogueSystem.InputBox("What is the name of the file?");
                player = FileSystem.Load(fileName);
                break;
            case 4:
                fileName = DialogueSystem.InputBox("What is the name of the file?");
                FileSystem.Save(fileName);
                break;
            case 5:
                _running = false;
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }
    }

    private void StartGame(Player playerData, bool newGame)
    {
        Random random = new();
        player = playerData;

        Console.Clear();

        RoomSystem roomSystem = new();
        roomSystem.GenRooms(random.Next(3, 10));

        if (newGame)
        {
            string playerName = DialogueSystem.InputBox("What is your name? ");
            player.SetName(playerName);
            Console.Clear();
            DialogueSystem.DialogueBox("Your journey begins.");
        }

        Console.Clear();

        roomSystem.Dungeon(player);
    }

    private void Menu()
    {
        string[] menu = [
            "MENU",
            "1. Start New Run",
            "2. Continue",
            "3. Load",
            "4. Save",
            "5. Quit ",
        ];

        foreach (string line in menu)
        {
            Console.WriteLine(line);
        }
    }
}