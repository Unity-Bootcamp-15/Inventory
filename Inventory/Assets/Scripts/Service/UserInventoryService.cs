using ErrorOr;
using System;
using System.Diagnostics;
using TMPro.EditorUtilities;

public sealed class UserInventoryService
{
    private readonly ItemService _itemService;

    private readonly Inventory _inventory;

    public UserInventoryService(ItemService itemService, Inventory inventory)
    {
        Debug.Assert(itemService != null);
        Debug.Assert(inventory != null);

        _itemService = itemService;
        _inventory = inventory;
    }

    public ErrorOr<Updated> AcquireRandomItem()
    {
        int itemId = _itemService.GetRandomId();
        UserInventoryItem newItem = UserInventoryItem.Create(itemId);

        return _inventory.AddItem(newItem);
    }
}