using UnityEngine;

[CreateAssetMenu(fileName = "UserInventoryServiceLocatorSO", menuName = "Service Locator SO/UserInventoryServiceLocatorSO")]
public class UserInventoryServiceLocatorSO : ScriptableObject
{
    public InventoryService Service { get; private set; }

    public void Init(ItemService itemService)
    {
        Service = new InventoryService(itemService);
    }
}
