namespace FinalProject.GameSystems
{
    class RoomSystem
    {
        public static List<Room> GenRooms(int dungeonSize)
        {
            List<Room> rooms = new();

            for (int i = 0; i < dungeonSize; i++)
            {
                Room room = new(i);

                if (i != 0)
                {
                    room.SetPreviousRoom(rooms[i - 1]);
                }

                if (i != dungeonSize && i != 0)
                {
                    rooms[i - 1].SetNextRoom(room);
                }

                rooms.Add(room);
            }

            return rooms;
        }

        public static void DisplayMap(List<Room> rooms, Room currentRoom)
        {
            string map = "ROOMS: ";

            foreach (Room room in rooms)
            {
                int roomNum = room.GetRoomNum() + 1;
                if (room == currentRoom)
                {
                    if (roomNum != rooms.Count)
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
                    if (roomNum != rooms.Count)
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

        public static Room AdvanceRoom(Room currentRoom)
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