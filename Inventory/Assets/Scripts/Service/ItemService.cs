using System;
using System.Collections.Generic;
using System.Diagnostics;

public sealed class ItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        Debug.Assert(itemRepository != null);

        _itemRepository = itemRepository;
    }

    public int GetRandomId()
    {
        // 1. 모든 아이템 목록을 가져온다.
        IReadOnlyList<Item> items = _itemRepository.All;
        // 2. 무작위로 아이템을 하나 선정한다.
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(items.Count);
        Item randomItem = items[randomIndex];
        // 3. 아이템의 ID를 반환한다.
        return randomItem.Id;
    }
}