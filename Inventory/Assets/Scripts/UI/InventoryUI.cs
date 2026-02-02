using Gpm.Ui;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InfiniteScroll _scroll;
    [SerializeField] private UserInventoryServiceLocatorSO _userInventoryServiceLocator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Refresh();   
    }

    public void Refresh()
    {
        _scroll.ClearData();

        // 인벤토리에 있는 아이템을 가져와서 => UserInventoryService
        foreach (BagItem item in _userInventoryServiceLocator.Service.UnequippedItems)
        {
            // item.ItemId에 해당되는 Grade 스프라이트, Icon 스프라이트
            
            // _scroll에 추가한다.
            var data = new InventoryItemSlotData();
            _scroll.InsertData(data);
        }
    }
}
