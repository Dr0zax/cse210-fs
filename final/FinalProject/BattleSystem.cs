class BattleSystem
{
    private Character _turn;

    public void Battle(Player player, Enemy enemy)
    {
        Console.WriteLine("\nBATTLE START!");
        bool battle = true;
        _turn = player;

        // Console.Clear();

        while (battle)
        {
            // Console.Clear();
            Console.WriteLine($"Current Turn: {_turn}");
            DisplayStats(player, enemy);

            if (_turn == player)
            {
                Console.WriteLine("\nCHOICES: ");
                Console.WriteLine("1. Attack");
                Console.Write(">");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        player.Attack(enemy);
                        break;
                    default:
                        break;
                }
            } 
            else
            {
                enemy.Attack(player);
            }

            if (player.GetHP() == 0)
            {
                //Player Loses
                battle = false;
            }
            else if (enemy.GetHP() == 0)
            {
                Console.WriteLine("PLAYER WINS");
                int reward = enemy.GetXpReward();
                player.GetLvlSystem().AddXP(reward);
                battle = false;
            }
            else
            {
                AdvanceTurn(player, enemy);
            }
        }
    }

    public void AdvanceTurn(Player player, Enemy enemy)
    {
        if (_turn == player)
        {
            _turn = enemy;
        }
        else 
        {
            _turn = player;
        }
    }

    public void DisplayStats(Player player, Enemy enemy)
    {
        string playerName = player.GetName();
        int playerHP = player.GetHP();
        int playerLvl = player.GetLvlSystem().GetLvl();
        Weapon PlayerEquipedWeapon = player.GetEquipedWeapon();

        string enemyName = enemy.GetName();
        int enemyHP = enemy.GetHP();
        int enemyLvl = enemy.GetLvlSystem().GetLvl();

        string statsString = $"| lvl {playerLvl} {playerName} | HP: {playerHP} |\n| lvl {enemyLvl} {enemyName} | HP: {enemyHP} |";
        Console.WriteLine(statsString);
    }
}