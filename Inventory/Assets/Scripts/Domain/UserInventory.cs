using System.Diagnostics;

public sealed class UserInventory
{
    private readonly Bag _inventory;

    public UserInventory(Bag inventory)
    {
        Debug.Assert(inventory != null);

        _inventory = inventory;
    }
}