class Character
{
    private int _hp;

    //STATS
    private int _attack;
    private int _defense;

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
}