using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;



public sealed class ItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        Debug.Assert(itemRepository != null);

        _itemRepository = itemRepository;
    }

    public ItemId GetRandomId()
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

    private const string k_TexturePath = "Textures";
    public string GetGradeSpritePath(ItemId id)
    {
        ItemGrade grade = id.Grade;
        return Path.Combine(k_TexturePath, grade.ToString()); 
    }

    public string GetIconSpritePath(ItemId id)
    {
        StringBuilder sb = new(id.RawId.ToString());
        sb[1] = '1';
        return Path.Combine(k_TexturePath, sb.ToString());
    }
}