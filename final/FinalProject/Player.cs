class Player : Character
{
    private Inventory _inventory = new();
    private Weapon _equipedWeapon;
    
    private double _critChance;
    private int _baseCritChance = 5;
    private Room _location;

    public Player(int xp, int lvl, int baseHP, int baseAttack, int baseDefense, string name) : base(xp, lvl, baseHP, baseAttack, baseDefense, name)
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

    public void SetLocation(Room location)
    {
        _location = location;
    }

    public Room GetLocation()
    {
        return _location;
    }

    public Weapon GetEquipedWeapon()
    {
        return _equipedWeapon;
    }

    public void SetEquipedWeapon(Weapon weapon)
    {
        _equipedWeapon = weapon;
    }

    public override void CalcStats()
    {
        base.CalcStats();

        int lvl = GetLvlSystem().GetLvl();
        int baseCritChance = GetBaseCritChance();
        double critChance = Math.Min((baseCritChance + (lvl * 0.5))/100, 1);

        SetCritChance(critChance);
    }

    // public override void Die()
    // {
    //     // throw new NotImplementedException();
    // }
}