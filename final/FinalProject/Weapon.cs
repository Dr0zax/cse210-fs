class Weapon : Item
{
    private int _atk;
    private double _critModifier = 1.5;

    public Weapon(string name, string description, int size, int attack) : base(name, description, size)
    {
        _atk = attack;
    }

    public override void Display()
    {
        string name = GetName();
        string description = GetDescription();
        int size = GetSize();
        string formatedString = $"{name}: {description}\nattack: {_atk}\nsize: {size}";

        Console.WriteLine(formatedString);
    }

    public int GetAttack(double critChance)
    {
        Random random = new();
        int attackAmount = _atk;

        if (random.NextDouble() < critChance)
        {   
            attackAmount = (int)Math.Ceiling(attackAmount * _critModifier);
        }

        return attackAmount;
    }
}