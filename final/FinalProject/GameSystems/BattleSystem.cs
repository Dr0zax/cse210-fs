namespace FinalProject.GameSystems
{
    class BattleSystem
    {
        public static void Battle(Player player, Enemy enemy, Character turn)
        {
            DialogueSystem.DialogueBox("\nBATTLE START!");
            bool battle = true;

            while (battle)
            {
                Console.Clear();
                Console.WriteLine($"Current Turn: {turn}");
                DisplayStats(player, enemy);

                if (turn == player)
                {
                    int choice = 0;

                    Console.WriteLine("\nCHOICES: ");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Heal");

                    try
                    {
                        choice = int.Parse(DialogueSystem.InputBox(""));
                    }
                    catch (System.FormatException)
                    {
                        DialogueSystem.DialogueBox("Invalid Option");
                    }

                    switch (choice)
                    {
                        case 1:
                            player.Attack(enemy);
                            turn = AdvanceTurn(player, enemy, turn);
                            break;
                        case 2:
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
                            break;
                    }
                }
                else
                {
                    enemy.Attack(player);
                    turn = AdvanceTurn(player, enemy, turn);
                }

                if (player.GetHP() == 0)
                {
                    battle = false;
                }
                else if (enemy.GetHP() == 0)
                {
                    Console.Clear();
                    DialogueSystem.DialogueBox("Player Wins!");

                    int reward = enemy.GetXpReward();
                    player.AddXP(reward);

                    battle = false;
                }
            }
        }

        private static Character AdvanceTurn(Player player, Enemy enemy, Character turn)
        {
            if (turn == player)
            {
                turn = enemy;
            }
            else
            {
                turn = player;
            }
            return turn;
        }

        private static void DisplayStats(Player player, Enemy enemy)
        {
            string playerName = player.GetName();
            int playerHP = player.GetHP();
            int playerMaxHP = player.GetMaxHP();
            int playerLvl = player.GetLvl();
            // Weapon PlayerEquipedWeapon = player.GetEquipedWeapon();

            string enemyName = enemy.GetName();
            int enemyHP = enemy.GetHP();
            int enemyMaxHP = enemy.GetMaxHP();
            int enemyLvl = enemy.GetLvl();

            string statsString = $"| lvl {playerLvl} {playerName} | HP: {playerHP}/{playerMaxHP} |\n| lvl {enemyLvl} {enemyName} | HP: {enemyHP} |";
            Console.WriteLine(statsString);
        }
    }
}