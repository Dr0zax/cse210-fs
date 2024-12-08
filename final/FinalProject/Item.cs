abstract class Item 
{
    private string _name;
    private string _description;
    private int _size;

    public Item(string name, string description, int size)
    {
        _name = name;
        _description = description;
        _size = size;
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

    public int GetSize()
    {
        return _size;
    }

    public void SetSize(int size)
    {
        _size = size;
    }

    public abstract void Display();
}