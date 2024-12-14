using FinalProject.GameSystems;

class HealingItem : Item
{

    private int _healAmount;
    // private bool _used = false;

    public HealingItem(string name, string description, int healAmount) : base(name, description)
    {
        _healAmount = healAmount;
    }

    // public bool IsUsed() 
    // {
    //     return _used;
    // }

    public void Use(Player player)
    {
        player.SetHP(_healAmount + player.GetHP());
        DialogueSystem.DialogueBox($"{player.GetName()} Healed {_healAmount} HP!");
        // _used = true;
    }

    public override void Display()
    {
        string name = GetName();
        string description = GetDescription();
        string formatedString = $"{name}: {description}\nHeal Amount: {_healAmount}";

        Console.WriteLine(formatedString);
    }

     public override string Serialize()
    {
        string name = GetName();
        string description = GetDescription();
        return $"{this}:{name}:{description}:{_healAmount}";
    }
}