using System.Diagnostics;

public sealed class UserInventory
{
    private readonly Inventory _inventory;

    public UserInventory(Inventory inventory)
    {
        Debug.Assert(inventory != null);

        _inventory = inventory;
    }
}