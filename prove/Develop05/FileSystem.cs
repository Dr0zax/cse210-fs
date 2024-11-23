class FileSystem {
    public void SaveFile(string fileName, LevelSystem levelSystem, List<Goal> goals)
    {
        // LEVEL SYSTEM FORMAT
        // level,xp
        int level = levelSystem.GetLevel();
        int xp = levelSystem.GetXP();
        string levelString = $"{level},{xp}";
    
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(levelString);

            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.Serialize());
            }
        }
    }

    public void LoadFile(string fileName, LevelSystem levelSystem, List<Goal> goals)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (var line in lines.Select((x, i) => new {Value = x, Index = i}))
        {
            string[] parts = line.Value.Split(",");

            if (line.Index == 0)
            {
                int level = int.Parse(parts[0]);
                int xp = int.Parse(parts[1]);

                levelSystem.SetLevel(level);
                levelSystem.SetXP(xp);
            }
            else if (parts[0] == "simple")
            {
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int value = int.Parse(parts[3]);
                bool completed = bool.Parse(parts[4]);

                Goal simpleGoal = new SimpleGoal(type, name, description, value, completed);
                goals.Add(simpleGoal);
            }
            else if (parts[0] == "eternal")
            {
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int value = int.Parse(parts[3]);

                Goal eternalGoal = new EternalGoal(type, name, description, value, false);
                goals.Add(eternalGoal);
            }
            else if (parts[0] == "checklist")
            {
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int value = int.Parse(parts[3]);
                int bonusValue = int.Parse(parts[4]);
                int requirement = int.Parse(parts[5]);
                int timesCompleted = int.Parse(parts[6]);
                bool completed = bool.Parse(parts[7]);

                Goal checklistGoal = new ChecklistGoal(type, name, description, value, bonusValue, requirement, timesCompleted, completed);
                goals.Add(checklistGoal);
            }
        }
    }
}