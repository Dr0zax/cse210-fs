using FinalProject.GameSystems;

abstract class Character
{
    private int _lvl;

    private string _name;
    //STATS
    private int _hp;
    private int _maxHP;
    private int _attack;
    private int _defense;

    //BASE STATS
    private int _baseHP;
    private int _baseAttack;
    private int _baseDefense;

    public Character(int lvl, int baseHP, int baseAttack, int baseDefense, string name)
    {
        _lvl = lvl;

        _baseHP = baseHP;
        _baseAttack = baseAttack;
        _baseDefense = baseDefense;
        _name = name;

        CalcStats();
        _hp = (int)Math.Floor(baseHP + (lvl * 1.5));
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

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetLvl(int lvl)
    {
        _lvl = lvl; 
    }

    public int GetLvl()
    {
        return _lvl; 
    }

    public void SetMaxHP(int hp)
    {
        _maxHP = hp; 
    }

    public int GetMaxHP()
    {
        return _maxHP; 
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
    public void Attack(Character attacked)
    {
        int damage = GetAttack();
        attacked.TakeDamage(damage);
        DialogueSystem.DialogueBox($"\n{attacked.GetName()} took {damage} damage!");
    }

    public virtual void CalcStats()
    {
        int lvl = GetLvl();
        int baseAttack = GetBaseAttack();
        int baseDefense = GetBaseDefense();
        int baseHP = GetBaseHP();

        int attack = (int)Math.Ceiling(baseAttack + (lvl * 1.75));
        int defense = (int)Math.Floor(baseDefense + (lvl * 1.5));
        int maxHP = (int)Math.Floor(baseHP + (lvl * 1.5));

        SetAttack(attack);
        SetDefense(defense);
        SetMaxHP(maxHP);
    }
}