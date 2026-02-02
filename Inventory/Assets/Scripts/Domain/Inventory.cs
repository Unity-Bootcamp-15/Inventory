using ErrorOr;
using System.Collections.Generic;
using UnityEngine.Assertions;

public sealed class Inventory
{
    public IReadOnlyCollection<BagItem> UnequippedItems => _bag.AllItems;

    private readonly Bag _bag;

    public Inventory(Bag bag)
    {
        Assert.IsNotNull(bag);

        _bag = bag;
    }

    public static Inventory CreateEmpty()
    {
        Bag bag = new Bag(new List<BagItem>());
        return new Inventory(bag);
    }
    
    public ErrorOr<Updated> AddItem(BagItem item) => _bag.AddItem(item);
}