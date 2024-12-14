using FinalProject.GameSystems;

class Inventory {
    private List<Item> _inventory = new();

    public Inventory()
    {
        
    }

    public Inventory(List<Item> inventory)
    {
        _inventory = inventory;
    }

    public void AddItem(Item item, int quanitiy = 1)
    {
        for (int i = 0; i <= quanitiy - 1; i++)
        {
            _inventory.Add(item);
        }
    }

    public List<Item> GetInventory()
    {
        return _inventory;
    }

    public List<HealingItem> GetHealingItems()
    {
        List<HealingItem> healingItems = new();

        foreach (Item item in _inventory)
        {
            if (item is HealingItem healingItem)
            {
                healingItems.Add(healingItem);
            }
        }
        
        return healingItems;
    }

    public List<Weapon> GetWeapons()
    {
        List<Weapon> weapons = new();

        foreach (Item item in _inventory)
        {
            if (item is Weapon weapon)
            {
                weapons.Add(weapon);
            }
        }

        return weapons;
    }

    public void SetInventory(List<Item> items)
    {
        _inventory = items;
    }

    public void DisplayInventory()
    {
        foreach (Item item in _inventory)
        {
            item.Display();
        }
        DialogueSystem.DialogueBox("");
    }
}