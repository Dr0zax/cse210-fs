public abstract class Goal 
{
    private string _type;
    private int _value;
    private string _name;
    private string _description;

    private bool _completed = false;

    public Goal(string type)
    {
        _type = type;
        GoalPrompt();
    }

    public Goal(string type, string name, string description, int value, bool completed)
    {
        _type = type;
        _name = name;
        _description = description;
        _value = value;
        _completed = completed;
    }

    public string GetGoalType()
    {
        return _type;
    }

    public void SetGoalType(string type)
    {
        _type = type;
    }

    public int GetValue()
    {
        return _value;
    }

    public void SetValue(int value)
    {
        _value = value;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public bool GetCompleted()
    {
        return _completed;
    }

    public void SetCompleted(bool state)
    {
        _completed = state;
    }

    public virtual void GoalPrompt()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();

        Console.Write("Write a short description of this goal: ");
        _description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        _value =  int.Parse(Console.ReadLine());
    }

    public abstract int Complete();

    public abstract string Serialize();
}