using FinalProject.GameSystems;

class Game
{
    private bool _running;
    private Player _player;
    private List<Room> _rooms;

    public Game()
    {
        _running = true;
    }

    public void Run()
    {
        while (_running)
        {
            Console.Clear();
            StartMenu();
        }
    }
    private void Start(Player playerData, bool newGame)
    {
        Random random = new();
        _player = playerData;

        Console.Clear();

        _rooms = RoomSystem.GenRooms(3);//_rooms = RoomSystem.GenRooms(random.Next(5, 10));

        if (newGame)
        {
            string playerName = DialogueSystem.InputBox("What is your name? ");
            _player.SetName(playerName);
            _player.GetInventory().AddItem(new Weapon("Basic Sword", "A sturdy sword perfect for the average traveler.", 5), 1);
            _player.SetEquipedWeapon(_player.GetInventory().GetWeapons()[0]);
            Console.Clear();
            DialogueSystem.DialogueBox("Your journey begins.");
        }

        Console.Clear();

        Dungeon(_player);
    }

    public void Dungeon(Player player)
    {
        Room currentRoom = _rooms[0];

        bool currentRun = true;

        while (currentRun)
        {
            Console.Clear();
            player.SetLocation(currentRoom);
            RoomSystem.DisplayMap(_rooms, currentRoom);

            string command = DialogueSystem.InputBox("What do you do? (search, fight, advance, inventory, heal)");

            switch (command.ToLower())
            {
                case "search":
                    List<Enemy> enemies = currentRoom.GetEnemies();
                    List<Item> loot = currentRoom.GetLoot();

                    DialogueSystem.DialogueBox("You search the room...");

                    Console.WriteLine("While searching the room you found:");

                    Console.WriteLine("Enemies:");

                    foreach (Enemy enemy in enemies)
                    {
                        enemy.Display();
                    }

                    Console.WriteLine("Loot:");

                    foreach (Item item in loot)
                    {
                        item.Display();
                        player.GetInventory().AddItem(item);
                    }

                    currentRoom.GetLoot().Clear();

                    DialogueSystem.DialogueBox("");

                    break;
                case "advance":
                    if (currentRoom.GetNextRoom() != null)
                    {
                        currentRoom = RoomSystem.AdvanceRoom(currentRoom);
                    }
                    else
                    {
                        Console.Clear();
                        DialogueSystem.DialogueBox("You beat the dungeon!");
                        currentRun = false;
                    }
                    break;
                case "fight":
                    enemies = currentRoom.GetEnemies();
                    if (enemies.Count != 0)
                    {
                        BattleSystem.Battle(_player, enemies[0], _player);
                        enemies.Remove(enemies[0]);
                    }
                    else
                    {
                        DialogueSystem.DialogueBox("There are no more enemies.");
                    }
                    break;
                case "inventory":
                    player.GetInventory().DisplayInventory();
                    break;
                case "heal":
                    Inventory inventory = player.GetInventory();
                    List<HealingItem> healingItems = inventory.GetHealingItems();

                    if (healingItems.Count == 0)
                    {
                        DialogueSystem.DialogueBox("You dont have any healing items in your inventory.");
                    }
                    else if (player.GetHP() == player.GetMaxHP())
                    {
                        DialogueSystem.DialogueBox("Your health is already full");
                    }
                    else
                    {
                        healingItems[0].Use(player);
                        healingItems.Remove(healingItems[0]);
                    }
                    break;
                default:
                    DialogueSystem.DialogueBox("Invalid Option");
                    break;
            }

            if (player.GetHP() == 0)
            {
                Console.Clear();
                DialogueSystem.DialogueBox("GAME OVER");
                currentRun = false;
            }
        }
    }

    private void StartMenu()
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

        ProcessStartMenu();
    }

    private void ProcessStartMenu()
    {
        int menuChoice = 0;

        try
        {
            menuChoice = int.Parse(DialogueSystem.InputBox(""));
        }
        catch (FormatException)
        {
            DialogueSystem.DialogueBox("Invalid Option");
        }

        switch (menuChoice)
        {
            case 1:
                Start(new(0, 1, 25, 5, 5, ""), true);
                break;
            case 2:
                if (_player != null)
                {
                    Start(_player, false);
                }
                else
                {
                    DialogueSystem.DialogueBox("No current save data.");
                }
                break;
            case 3:
                string fileName = DialogueSystem.InputBox("What is the name of the file?");
                _player = FileSystem.Load(fileName);
                break;
            case 4:
                fileName = DialogueSystem.InputBox("What is the name of the file?");
                FileSystem.Save(fileName, _player);
                break;
            case 5:
                _running = false;
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }
    }

}