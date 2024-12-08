class Enemy : Character
{
    private int _xpReward;
    public Enemy(int lvl, int baseHP, int baseAttack, int baseDefense, string name) : base(lvl, baseHP, baseAttack, baseDefense, name)
    {
        
    }

    public int GetXpReward()
    {
        return _xpReward;
    }

    public void SetXpReward(int xpReward)
    {
        _xpReward = xpReward;
    }

    public override void CalcStats()
    {
        base.CalcStats();

        int lvl = GetLvlSystem().GetLvl();
        int xpReward = (int)Math.Ceiling(10 + (lvl * 1.75));
        
        SetXpReward(xpReward);
    }

    // public override void Die()
    // {
    //     // throw new NotImplementedException();
    // }
}