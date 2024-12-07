abstract class Character
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
    public Character(int xp, int lvl, int baseHP, int baseAttack, int baseDefense)
    {
        _levelSystem.SetLevel(lvl);
        _levelSystem.SetXP(xp);

        _baseHP = baseHP;
        _baseAttack = baseAttack;
        _baseDefense = baseDefense;

        CalcStats();
    }

    //for creating and enemy
    public Character(int lvl, int baseHP, int baseAttack, int baseDefense)
    {
        _levelSystem.SetLevel(lvl);

        _baseHP = baseHP;
        _baseAttack = baseAttack;
        _baseDefense = baseDefense;

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
        return _baseHP;
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

    public int GetLvl()
    {
        return _levelSystem.GetLvl();
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

    public virtual void CalcStats()
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

    public abstract void Die();
}