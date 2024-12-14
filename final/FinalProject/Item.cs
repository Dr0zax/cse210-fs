abstract class Item 
{
    private string _name;
    private string _description;
    public Item(string name, string description)
    {
        _name = name;
        _description = description;
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

    public string GetQuantity()
    {
        return _description;
    }

    public void SetQuantity(string description)
    {
        _description = description;
    }

    public virtual void Display() 
    {
        string name = GetName();
        string description = GetDescription();
        string formatedString = $"{name}: {description}";

        Console.WriteLine(formatedString);
    }

    public abstract string Serialize();
}