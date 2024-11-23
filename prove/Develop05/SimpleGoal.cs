public class SimpleGoal : Goal
{
    public SimpleGoal(string type) : base(type)
    {

    }

    public SimpleGoal(string type, string name, string description, int value, bool completed) : base(type, name, description, value, completed)
    {

    }

    public override int Complete()
    {
        SetCompleted(true);
        int value = GetValue();
        return value;
    }

    public override string Serialize()
    {
        // SIMPLEGOAL FORMAT
        // type,name,description,value,completed
        return $"{GetGoalType()},{GetName()},{GetDescription()},{GetValue()},{GetCompleted()}";
    }

    public override string ToString()
    {
        return $"{GetName()} ({GetDescription()})";
    }
}