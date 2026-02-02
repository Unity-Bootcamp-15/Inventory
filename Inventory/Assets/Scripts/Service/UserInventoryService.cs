using ErrorOr;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro.EditorUtilities;

public sealed class UserInventoryService
{
    private readonly ItemService _itemService;

    private readonly Inventory _inventory;

    public IReadOnlyCollection<UserInventoryItem> UnequippedItems => _inventory.AllItems;

    public UserInventoryService(ItemService itemService)
    {
        Debug.Assert(itemService != null);
        //Debug.Assert(inventory != null);

        _itemService = itemService;
        _inventory = new Inventory(new List<UserInventoryItem>());
    }

    public ErrorOr<Updated> AcquireRandomItem()
    {
        ItemId itemId = _itemService.GetRandomId();
        UserInventoryItem newItem = UserInventoryItem.Create(itemId);

        return _inventory.AddItem(newItem);
    }

}