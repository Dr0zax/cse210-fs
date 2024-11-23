public class ChecklistGoal : Goal
{
    private int _bonusValue;
    private int _requirement;
    private int _timesCompleted = 0;

    public ChecklistGoal() : base()
    {

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
            SetComplete(true);
            return _bonusValue + GetValue();
        }
    }
}