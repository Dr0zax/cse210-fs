class LevelSystem
{
    private int _xp;
    private int _lvl;
    private int _nextLvl;

    public LevelSystem()
    {
        _xp = 0;
        _lvl = 1;
        _nextLvl = NextLvl(_lvl);
    }

    public LevelSystem(int lvl, int xp)
    {
        _xp = xp;
        _lvl = lvl;
        _nextLvl = NextLvl(_lvl);
    }

    private int NextLvl(int level)
    {
        return (int)Math.Round(0.01 * Math.Pow(level, 3) + 0.02 * Math.Pow(level, 2) + level * 2);
    }

    public void AddXP(int xp)
    {
        if (_xp + xp >= _nextLvl)
        {
            int leftover = _xp + xp - _nextLvl;
            LevelUp();
            AddXP(leftover);
        }
        else
        {
            SetXP(_xp + xp);
        }
    }

    public void LevelUp()
    {
        SetXP(0);
        SetLevel(_lvl++);
        _nextLvl = NextLvl(_lvl);
    }

    public int GetXP()
    {
        return _xp;
    }

    public void SetXP(int xp)
    {
        _xp = xp;
    }

    public int GetLvl()
    {
        return _lvl;
    }

    public void SetLevel(int lvl)
    {
        _lvl = lvl;
    }
}