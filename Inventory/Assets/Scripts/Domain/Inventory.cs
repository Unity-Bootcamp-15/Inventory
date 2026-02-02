using System.Diagnostics;

public sealed class Inventory
{
    private readonly Bag _inventory;

    public Inventory(Bag inventory)
    {
        Debug.Assert(inventory != null);

        _inventory = inventory;
    }
}