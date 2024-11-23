class LevelSystem
{
    private int _xp;
    private int _level;
    private int _levelThreshhold;

    public LevelSystem()
    {
        _xp = 0;
        _level = 1;
        _levelThreshhold = NextLevel(_level);
    }

    public int GetXP()
    {
        return _xp;
    }

    public void SetXP(int xp)
    {
        _xp = xp;
    }

    public void AddXP(int xp)
    {
        if (_xp + xp >= _levelThreshhold)
        {
            int leftover = _xp + xp - _levelThreshhold;
            LevelUp();
            AddXP(leftover);
        } 
        else 
        {
            _xp += xp;
        }

    }

    public int GetLevel()
    {
        return _level;
    }

    public void SetLevel(int level)
    {
        _level = level;
        _levelThreshhold = NextLevel(level);
    }

    // Calculates how much xp in needed to reach the next level
    private int NextLevel(int level)
    {
        return (int)Math.Round(0.01 * Math.Pow(level, 3) + 0.02 * Math.Pow(level, 2) + level * 2);
    }

    private void LevelUp()
    {
        _level++;
        _xp = 0;
        _levelThreshhold = NextLevel(_level);
    }

    public void GenerateLevelBar()
    {
        string bar = "";
        string barSection = "█";
        int barSize = 20;
        
        // Mapping the xp to level ratio bewteen 0 and 1
        double mapped = (double)_xp / (double)_levelThreshhold;

        // The amount of xp each section of the bar represents
        double sections = Math.Floor(mapped * barSize);

        for (int i = 0; i<barSize; i++)
        {
            if (i < sections) 
            {
                bar += barSection;
            } 
            else 
            {
                bar += " ";
            }
        }
        
        Console.WriteLine($"LVL: {_level} [{bar}] XP: {_xp}/{_levelThreshhold}\n");
    }
}