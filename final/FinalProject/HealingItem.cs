class HealingItem : Item
{

    private int _healAmount;
    public HealingItem(int healAmount, string name, string description, int size) : base(name, description, size)
    {
        _healAmount = healAmount;
    }

    public override void Display()
    {
        string name = GetName();
        string description = GetDescription();
        int size = GetSize();
        string formatedString = $"{name}: {description}\nHeal Amount: {_healAmount}\nsize: {size}";

        Console.WriteLine(formatedString);
    }
}