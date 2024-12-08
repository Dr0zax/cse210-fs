class RoomSystem
{
    private List<Room> _rooms = new();

    public void GenRooms(int dungeonSize)
    {
        for (int i = 0; i < dungeonSize; i++)
        {
            Room room = new(i);

            if (i != 0)
            {
                room.SetPreviousRoom(_rooms[i-1]);
            }

            if (i != dungeonSize && i != 0)
            {
                _rooms[i-1].SetNextRoom(room);
            }

            _rooms.Add(room);       
        }
    }

    public void ClearRooms()
    {
        _rooms.Clear();
    }

    public void Dungeon(Player player)
    {
        BattleSystem battleSystem = new();

        //puts the player in the first room
        Room currentRoom = _rooms[0];

        bool alive = true;

        while (alive)
        {
            player.SetLocation(currentRoom);

            foreach (Enemy enemy in currentRoom.GetEnemies())
            {
                battleSystem.Battle(player, enemy);
                
                // if (player.GetHP() == 0)
                // {
                //     alive = false;
                // }
            }

            Room NextRoom = currentRoom.GetNextRoom();

            if (NextRoom != null)
            {
                currentRoom = NextRoom;
            }
            else
            {
                alive = false;
            }
        }
    }

    public void DisplayRooms()
    {
        foreach (Room room in _rooms)
        {
            Console.WriteLine("");

            Console.WriteLine($"ROOM {room.GetRoomNum()}:");

            if (room.GetPreviousRoom() != null)
            {
                Console.WriteLine($"Previous Room: {room.GetPreviousRoom().GetRoomNum()}");
            }

            if (room.GetNextRoom() != null)
            {
                Console.WriteLine($"Next Room: {room.GetNextRoom().GetRoomNum()}");
            }


            Console.WriteLine($"Num of Enemies: {room.GetEnemies().Count()}");

        }
    }
}