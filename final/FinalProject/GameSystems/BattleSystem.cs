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
                    //Player Loses
                    battle = false;
                }
                else if (enemy.GetHP() == 0)
                {
                    Console.Clear();
                    Console.WriteLine("PLAYER WINS");
                    enemy.SetIsDead(true);
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