class Bin
{
    private string _demomination;
    private int _amount;
    private int _value;

    public Bin(string demomination, int amount, int value)
    {
        _demomination = demomination;
        _amount = amount;
        _value = value;
    }

    public void ModifyAmount(int amount)
    {
        _amount += amount;
    }

    public float TotalValue()
    {
        return _amount * _value;
    }
}