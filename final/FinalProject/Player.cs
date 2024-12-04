class Player : Character
{
    private LevelSystem _levelSystem = new();
    private Inventory _inventory = new();

    //STATS
    private int _critChance;

    public Player()
    {
        
    }

    public Player(int xp, int lvl)
    {
        _levelSystem.SetXP(xp);
        _levelSystem.SetLevel(lvl);
    }
}