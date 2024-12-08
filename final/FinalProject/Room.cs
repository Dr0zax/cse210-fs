class Room 
{
    private List<Enemy> _enemies = new();
    private Room _previousRoom = null;
    private Room _nextRoom = null;

    private int _roomNum;

    public Room(int roomNum)
    {
        _roomNum = roomNum;
        GenEnemies();
    }

    public void GenEnemies()
    {
        Random random = new();
        int enemyAmount = random.Next(1, 3);

        for (int i = 0; i < enemyAmount; i++)
        {
            Enemy enemy = new(2, 5, 2, 2, "Enemy");
            _enemies.Add(enemy);
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

    public bool IsClear()
    {
        if (_enemies.Count() == 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}