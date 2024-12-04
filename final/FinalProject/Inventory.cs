class Inventory {
    private List<Item> _inventory = new();
    private int size = 20;

    public Inventory()
    {
        
    }

    public Inventory(List<Item> inventory)
    {
        _inventory = inventory;
    }
}