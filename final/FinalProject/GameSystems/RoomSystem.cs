namespace FinalProject.GameSystems
{
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
                    room.SetPreviousRoom(_rooms[i - 1]);
                }

                if (i != dungeonSize && i != 0)
                {
                    _rooms[i - 1].SetNextRoom(room);
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
            //puts the player in the first room
            Room currentRoom = _rooms[0];

            bool currentRun = true;

            while (currentRun)
            {
                Console.Clear();
                player.SetLocation(currentRoom);
                Map(currentRoom);

                foreach (Enemy enemy in currentRoom.GetEnemies())
                {
                    BattleSystem.Battle(player, enemy, player);
                }

                Console.ReadLine();

                if (currentRoom.GetNextRoom() != null)
                {
                    currentRoom = AdvanceRoom(currentRoom);
                }
                else
                {
                    Console.Clear();
                    DialogueSystem.DialogueBox("You beat the dungeon!");
                    currentRun = false;
                }

            }
        }

        public void Map(Room currentRoom)
        {
            string map = "ROOMS: ";

            foreach (Room room in _rooms)
            {
                int roomNum = room.GetRoomNum() + 1;
                if (room == currentRoom)
                {
                    if (roomNum != _rooms.Count)
                    {
                        map += "P--";
                    }
                    else
                    {
                        map += "P";
                    }
                }
                else
                {
                    if (roomNum != _rooms.Count)
                    {
                        map += $"{roomNum}--";
                    }
                    else
                    {
                        map += $"{roomNum}";
                    }
                }
            }

            Console.SetCursorPosition((Console.WindowWidth - map.Length) / 2, Console.CursorTop);
            Console.WriteLine(map);
        }

        public Room AdvanceRoom(Room currentRoom)
        {
            Room nextRoom = currentRoom.GetNextRoom();

            bool isClear = currentRoom.IsClear();

            if (isClear)
            {
                DialogueSystem.DialogueBox("Entering Next Room");
                return nextRoom;
            }
            else
            {
                DialogueSystem.DialogueBox("You must clear the room first!");
                return currentRoom;
            }
        }
    }
}