using UnityEngine;

[CreateAssetMenu(fileName = "UserInventoryServiceLocatorSO", menuName = "Service Locator SO/UserInventoryServiceLocatorSO")]
public class UserInventoryServiceLocatorSO : ScriptableObject
{
    public UserInventoryService Service { get; private set; }

    public void Init(ItemService itemService)
    {
        Service = new UserInventoryService(itemService);
    }
}
