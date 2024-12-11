using FinalProject.GameSystems;

class Player : Character
{
    private Inventory _inventory = new();
    private Weapon _equipedWeapon;

    private int _xp;
    private int _nextLvl;
    
    private double _critChance;
    private int _baseCritChance = 5;
    private Room _location;

    public Player(int xp, int lvl, int baseHP, int baseAttack, int baseDefense, string name) : base(lvl, baseHP, baseAttack, baseDefense, name)
    {
        _xp = xp;
        _nextLvl = LevelSystem.NextLvl(lvl);
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

    public void AddXP(int xp)
    {
        LevelSystem.AddXP(this, xp);
    }

    public void SetXP(int xp)
    {
        _xp = xp;
    }

    public int GetXP()
    {
        return _xp;
    }

    public void SetEquipedWeapon(Weapon weapon)
    {
        _equipedWeapon = weapon;
    }

    public void LvlUp()
    {
        int lvl = GetLvl();
        int newLvl = lvl + 1;
        SetLvl(newLvl);
        _nextLvl = LevelSystem.NextLvl(newLvl);
        _xp = 0;
        CalcStats();
    }

    public override void CalcStats()
    {
        base.CalcStats();

        int lvl = GetLvl();
        int baseCritChance = GetBaseCritChance();
        double critChance = Math.Min((baseCritChance + (lvl * 0.5))/100, 1);

        SetCritChance(critChance);
    }
}