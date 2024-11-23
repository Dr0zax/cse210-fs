public class EternalGoal : Goal
{
    public EternalGoal(string type) : base(type)
    {

    }

    public EternalGoal(string type, string name, string description, int value, bool completed) : base(type, name, description, value, completed)
    {

    }
    
    public override int Complete()
    {
        return GetValue();
    }

    public override string Serialize()
    {
        //ETERNAL GOAL FORMAT
        //type,name,description,value
        return $"{GetGoalType()},{GetName()},{GetDescription()},{GetValue()}";
    }

    public override string ToString()
    {
        return $"{GetName()} ({GetDescription()})";
    }
}