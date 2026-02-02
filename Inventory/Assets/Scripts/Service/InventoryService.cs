using ErrorOr;
using System.Collections.Generic;
using UnityEngine.Assertions;

public sealed class InventoryService
{
    private readonly ItemService _itemService;
    private readonly IInventoryRepository _inventoryRepository;

    private Inventory _inventory;

    public IReadOnlyCollection<BagItem> UnequippedItems => _inventory.UnequippedItems;

    public InventoryService(ItemService itemService, IInventoryRepository inventoryRepository)
    {
        Assert.IsNotNull(itemService);
        Assert.IsNotNull(inventoryRepository);
       
        _itemService = itemService;
        _inventoryRepository = inventoryRepository;

        _inventory = Inventory.CreateEmpty();
    }

    public ErrorOr<Updated> AcquireRandomItem()
    {
        ItemId itemId = _itemService.GetRandomId();
        BagItem newItem = BagItem.Create(itemId);

        return _inventory.AddItem(newItem);
    }

    public ErrorOr<Success> SaveData()
    {
        return _inventoryRepository.Save(_inventory);
    }

    public ErrorOr<Success> LoadData()
    {
        var result = _inventoryRepository.Load();
        if (result.IsError)
        {
            return Error.Failure(description: "인벤토리를 불러오는 데 실패하였습니다.");
        }

        _inventory = result.Value;
        return Result.Success;
    }
}