using System.Collections.Generic;
using UnityEngine;

public sealed class ItemRepository : IItemRepository
{
    public IReadOnlyList<Item> All => _items;

    private List<Item> _items = new();
    
    public void Load()
    {
        TextAsset itemsFile = Resources.Load<TextAsset>("Data/items");
        string json = itemsFile.text;

        ItemModels models = JsonUtility.FromJson<ItemModels>(json);
        foreach (ItemModel model in models.data)
        {
            Status status = new Status(model.attack_power, model.defense);
            Item newItem = new Item(model.item_id, model.item_name, status);
            _items.Add(newItem);
        }
    }

}