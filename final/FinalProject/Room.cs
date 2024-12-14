class Room 
{
    private List<Enemy> _enemies = new();
    private Room _previousRoom = null;
    private Room _nextRoom = null;
    private int _roomNum;

    private List<Item> _lootTable = [
        new HealingItem("Healing Potion", "A simple healing potion. Despite being able to heal any wound it doesnt taste very good", 10)
    ];

    private List<Item> _loot = new();

    public Room(int roomNum)
    {
        _roomNum = roomNum;
        GenEnemies();
        GenLoot();
    }

    public void GenEnemies()
    {
        Random random = new();
        int enemyAmount = random.Next(1, 3);

        for (int i = 0; i < enemyAmount; i++)
        {
            Enemy enemy = new(_roomNum + 1, 15, 5, 5, "Enemy");
            _enemies.Add(enemy);
        }
    }

    public void GenLoot()
    {
        Random random = new();

        int rolls = random.Next(1, 3);

        for (int i = 0; i <= rolls; i++)
        {
            _loot.Add(_lootTable[random.Next(_lootTable.Count)]);
        }
    }

    public void SetPreviousRoom(Room room)
    {
        _previousRoom = room;
    }

    public Room GetPreviousRoom()
    {
        return _previousRoom;
    }

    public void SetNextRoom(Room room)
    {
        _nextRoom = room;
    }

    public Room GetNextRoom()
    {
        return _nextRoom;
    }

    public List<Enemy> GetEnemies()
    {
        return _enemies;
    }

    public int GetRoomNum()
    {
        return _roomNum;
    }

    public List<Item> GetLoot()
    {
        return _loot;
    }

    public void RemoveLoot(Item item)
    {
        _loot.Remove(item);
    }

    public bool IsClear()
    {
        int enemyCount = _enemies.Count;

        if (enemyCount == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}