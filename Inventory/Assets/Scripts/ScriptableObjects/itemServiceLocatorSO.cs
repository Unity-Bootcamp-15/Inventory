using UnityEngine;

[CreateAssetMenu(fileName = "ItemServiceLocatorSO", menuName = "Service Locator SO/ItemServiceLocatorSO")]
public class ItemServiceLocatorSO : ScriptableObject
{
    public ItemService Service { get; private set; }

    public void Init(IItemRepository itemRepository)
    {
        Service = new ItemService(itemRepository);
    }
}
