using Gpm.Ui;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InfiniteScroll _scroll;
    [SerializeField] private UserInventoryServiceLocatorSO _userInventoryServiceLocator;
    [SerializeField] private ItemServiceLocatorSO _itemServiceLocator;

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
            var data = new InventoryItemSlotData();
            string gradeSpritePath = _itemServiceLocator.Service.GetGradeSpritePath(item.ItemId);
            data.ItemGradeSprite = Resources.Load<Sprite>(gradeSpritePath);
            string iconSpritePath = _itemServiceLocator.Service.GetIconSpritePath(item.ItemId);
            data.ItemIconSprite = Resources.Load<Sprite>(iconSpritePath);

            _scroll.InsertData(data);
        }
    }
}
