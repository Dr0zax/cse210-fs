namespace FinalProject.GameSystems
{
    class FileSystem
    {
        public static void Save(string fileName, Player player)
        {
            string name = player.GetName();
            int level = player.GetLvl();
            int xp = player.GetXP();

            int baseHP = player.GetBaseHP();
            int baseAttack = player.GetBaseAttack();
            int baseDefense = player.GetBaseDefense();
            Item equipedWeapon = player.GetEquipedWeapon();

            List<Item> inventory = player.GetInventoryItems();

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine($"{name}");
                outputFile.WriteLine($"{level},{xp}");
                outputFile.WriteLine($"{baseHP},{baseAttack},{baseDefense}");
                outputFile.WriteLine($"{equipedWeapon.Serialize()}");

                foreach (Item item in inventory)
                {
                    outputFile.Write($"{item.Serialize()},");
                }
            }
        }

        public static Player Load(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            string[] levelSystemData = lines[1].Split(",");
            string[] baseStatsData = lines[2].Split(",");
            string[] equipedWeaponData = lines[3].Split(":");
            string[] InventoryData = lines[4].Split(",");
            string name = lines[0];

            List<Item> inventory = new();

            int lvl = int.Parse(levelSystemData[0]);
            int xp = int.Parse(levelSystemData[1]);

            int baseHP = int.Parse(baseStatsData[0]);
            int baseAttack = int.Parse(baseStatsData[1]);
            int baseDefense = int.Parse(baseStatsData[2]);

            Player player = new(xp, lvl, baseHP, baseAttack, baseDefense, name);
            player.SetEquipedWeapon(new(equipedWeaponData[1], equipedWeaponData[2], int.Parse(equipedWeaponData[3])));

            foreach (string item in InventoryData)
            {
                string[] parts = item.Split(":");

                if (parts[0] == "HealingItem")
                {
                    inventory.Add(new HealingItem(parts[1], parts[2], int.Parse(parts[3])));
                }

                if (parts[0] == "Weapon")
                {
                    inventory.Add(new Weapon(parts[1], parts[2], int.Parse(parts[3])));
                }
            }

            player.GetInventory().SetInventory(inventory);

            return player;
        }
    }
}