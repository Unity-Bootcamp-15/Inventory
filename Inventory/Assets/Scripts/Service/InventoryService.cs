using ErrorOr;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro.EditorUtilities;

public sealed class InventoryService
{
    private readonly ItemService _itemService;

    private Inventory _inventory;

    public IReadOnlyCollection<BagItem> UnequippedItems => _inventory.AllItems;

    public InventoryService(ItemService itemService)
    {
        Debug.Assert(itemService != null);
        //Debug.Assert(inventory != null);

        _itemService = itemService;
        _inventory = new Bag(new List<BagItem>());
        _inventory = Inventory.CreateEmpty();
    }

    public ErrorOr<Updated> AcquireRandomItem()
    {
        ItemId itemId = _itemService.GetRandomId();
        BagItem newItem = BagItem.Create(itemId);

        return _inventory.AddItem(newItem);
    }

}