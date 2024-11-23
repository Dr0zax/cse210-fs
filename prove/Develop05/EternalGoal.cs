public class EternalGoal : Goal
{
    public EternalGoal() : base()
    {

    }
    
    public override int Complete()
    {
        return GetValue();
    }
}