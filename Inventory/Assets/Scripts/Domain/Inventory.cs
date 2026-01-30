using ErrorOr;
using System;
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

    public ErrorOr<Updated> AddItem(UserInventoryItem item)
    {
        Debug.Assert(item != null);

        if (_items.ContainsKey(item.SerialNumber))
        {
            return Error.Conflict(description: $"{item.SerialNumber}를 가진 아이템이 이미 인벤토리에 존재합니다.");
        }

        _items[item.SerialNumber] = item;
        return Result.Updated;
    }
}