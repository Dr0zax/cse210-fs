namespace FinalProject.GameSystems
{
    class LevelSystem
    {
        public static int NextLvl(int level)
        {
            return (int)Math.Round(0.01 * Math.Pow(level, 3) + 0.02 * Math.Pow(level, 2) + level * 2);
        }

        public static void AddXP(Player player, int addedXP)
        {
            int currentXP = player.GetXP();
            int lvl = player.GetLvl();
            int nextLvl = NextLvl(lvl);

            if (currentXP + addedXP >= nextLvl)
            {
                int leftover = currentXP + addedXP - nextLvl;
                player.LvlUp();
                AddXP(player, leftover);
            }

            player.SetXP(currentXP + addedXP);
        }
    }
}