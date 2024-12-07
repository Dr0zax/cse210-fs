class Player : Character
{
    private Inventory _inventory = new();
    private double _critChance;
    private int _baseCritChance = 5;

    public Player(int xp, int lvl, int baseHP, int baseAttack, int baseDefense) : base(xp, lvl, baseHP, baseAttack, baseDefense)
    {
        
    }

    public int GetBaseCritChance()
    {
        return _baseCritChance;
    }

    public void SetBaseCritChance(int critChance)
    {
        _baseCritChance = critChance;
    }

    public double GetCritChance()
    {
        return _critChance;
    }

    public void SetCritChance(double critChance)
    {
        _critChance = critChance;
    }

    public override void CalcStats()
    {
        base.CalcStats();

        int lvl = GetLvl();
        int baseCritChance = GetBaseCritChance();
        double critChance = Math.Min((baseCritChance + (lvl * 0.5))/100, 1);

        SetCritChance(critChance);
    }

    public override void Die()
    {
        // throw new NotImplementedException();
    }
}