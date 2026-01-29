using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public sealed class Inventory
{
    private readonly Dictionary<long, UserInventoryItem> _items = new();

    public Inventory(IList<UserInventoryItem> items)
    {
        Debug.Assert(items is not null);

        _items = items.ToDictionary(item => item.SerialNumber);
    }
}