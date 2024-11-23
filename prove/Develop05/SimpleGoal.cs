public class SimpleGoal : Goal
{
    public SimpleGoal() : base()
    {

    }

    public override int Complete()
    {
        SetComplete(true);
        int value = GetValue();
        return value;
    }
}