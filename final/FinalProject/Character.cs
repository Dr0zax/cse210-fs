class Character
{
    private LevelSystem _levelSystem = new();

    //STATS
    private int _hp;
    private int _attack;
    private int _defense;

    //BASE STATS
    private int _baseHP;
    private int _baseAttack;
    private int _baseDefense;

    //for creating a player
    public Character(int xp, int lvl)
    {
        _levelSystem.SetLevel(lvl);
        _levelSystem.SetXP(xp);
        CalcStats();
    }

    //for creating and enemy
    public Character(int lvl)
    {
        _levelSystem.SetLevel(lvl);
        CalcStats();
    }

    public int GetHP()
    {
        return _hp;
    }

    public void SetHP(int hp)
    {
        _hp = hp;
    }

    public int GetAttack()
    {
        return _attack;
    }

    public void SetAttack(int attack)
    {
        _attack = attack;
    }

    public int GetDefense()
    {
        return _defense;
    }

    public void SetDefense(int defense)
    {
        _defense = defense;
    }

    public int GetBaseHP()
    {
        return _baseDefense;
    }

    public void SetBaseHP(int hp)
    {
        _baseHP = hp;
    }

    public int GetBaseAttack()
    {
        return _baseAttack;
    }

    public void SetBaseAttack(int attack)
    {
        _baseAttack = attack;
    }

    public int GetBaseDefense()
    {
        return _baseDefense;
    }

    public void SetBaseDefense(int defense)
    {
        _baseDefense = defense;
    }


    public void TakeDamage(int damage)
    {
        int hp = GetHP();
        int defense = GetDefense();
        int damageTaken = (int)Math.Floor(damage / 1 + defense * 0.075);
        int newHp = hp - damageTaken;

        if (newHp > 0)
        {
            SetHP(newHp);
        }
        else
        {
            SetHP(0);
        }
    }
    public int Attack(Character attacked)
    {
        int damage = GetAttack();
        return 0;
    }

    public void CalcStats()
    {
        int lvl = _levelSystem.GetLvl();
        int baseAttack = GetBaseAttack();
        int baseDefense = GetBaseDefense();
        int baseHP = GetBaseHP();

        int hp = (int)Math.Floor(baseHP + (lvl * 1.5));
        int attack = (int)Math.Ceiling(baseAttack + (lvl * 1.75));
        int defense = (int)Math.Floor(baseDefense + (lvl * 1.5));

        SetAttack(attack);
        SetHP(hp);
        SetDefense(defense);
    }
}