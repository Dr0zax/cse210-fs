class LevelSystem
{
    private int _xp;
    private int _level;
    private int _levelThreshhold;

    // New save
    public LevelSystem()
    {
        _xp = 0;
        _level = 1;
        _levelThreshhold = NextLevel(_level);
    }

    // For loading from a save
    public LevelSystem(int xp, int level)
    {
        _xp = xp;
        _level = level;
        _levelThreshhold = NextLevel(_level);
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

    private int NextLevel(int level)
    {
        return (int)Math.Round(0.04 * Math.Pow(level, 3) + 0.08 * Math.Pow(level, 2) + level * 2);
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
        
        double mapped = (double)_xp / (double)_levelThreshhold;

        double sectionSize = Math.Floor(mapped * barSize);

        for (int i = 0; i<barSize; i++)
        {
            if (i < sectionSize) 
            {
                bar += barSection;
            } 
            else 
            {
                bar += " ";
            }
        }
        
        Console.WriteLine($"LVL: {_level} [{bar}] XP: {_xp}/{_levelThreshhold}");
    }

}