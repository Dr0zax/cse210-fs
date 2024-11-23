public class ChecklistGoal : Goal
{
    private int _bonusValue;
    private int _requirement;
    private int _timesCompleted;

    public ChecklistGoal(string type) : base(type)
    {
        _timesCompleted = 0;
    }

    public ChecklistGoal(string type, string name, string description, int value, int bonusValue, int requirement, int timesCompleted, bool completed) : base(type, name, description, value, completed)
    {
        _bonusValue = bonusValue;
        _requirement = requirement;
        _timesCompleted = timesCompleted;
    }

    public override void GoalPrompt()
    {
        base.GoalPrompt();

        Console.Write("How many times must this goal be completed? ");
        _requirement = int.Parse(Console.ReadLine());

        Console.Write("What is the bonus for completing this goal that many times? ");
        _bonusValue = int.Parse(Console.ReadLine());
    }

    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }

    public int GetRequirement()
    {
        return _requirement;
    }

    public int GetBonusValue()
    {
        return _bonusValue;
    }

    public override int Complete()
    {
        _timesCompleted++;

        if (_timesCompleted != _requirement)
        {
            return GetValue();
        } 
        else
        {
            // _timesCompleted--;
            SetCompleted(true);
            return _bonusValue + GetValue();
        }
    }

    public override string Serialize()
    {
        //CHECKLIST GOAL FORMAT
        //type,name,description,value,bonusValue,requirement,timesCompleted,complete
        return $"{GetGoalType()},{GetName()},{GetDescription()},{GetValue()},{GetBonusValue()},{GetRequirement()},{GetTimesCompleted()},{GetCompleted()}";
    }
    public override string ToString()
    {
        return $"{GetName()} ({GetDescription()}) -- Currently Completed {GetTimesCompleted()}/{GetRequirement()}";
    }
}