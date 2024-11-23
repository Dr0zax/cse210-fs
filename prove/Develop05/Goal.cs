public abstract class Goal 
{
    private int _value;
    private string _name;
    private string _description;

    private bool _isComplete = false;

    public Goal()
    {
        GoalPrompt();
    }

    public int GetValue()
    {
        return _value;
    }

    public void setValue(int value)
    {
        _value = value;
    }

    public string getName()
    {
        return _name;
    }

    public void setName(string name)
    {
        _name = name;
    }

    public string getDescription()
    {
        return _description;
    }

    public void setDescription(string description)
    {
        _description = description;
    }

    public bool GetComplete()
    {
        return _isComplete;
    }

    public void SetComplete(bool state)
    {
        _isComplete = state;
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
}