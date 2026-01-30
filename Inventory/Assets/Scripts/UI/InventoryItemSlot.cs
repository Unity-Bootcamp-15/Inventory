using Gpm.Ui;
using UnityEngine;
using UnityEngine.UI;

public sealed class InventoryItemSlotData : InfiniteScrollData
{
    public Sprite ItemGradeSprite;
    public Sprite ItemIconSprite;
}

public class InventoryItemSlot : InfiniteScrollItem
{
    [SerializeField] private Image ItemGradeImage;
    [SerializeField] private Image ItemIconImage;

    public override void UpdateData(InfiniteScrollData scrollData)
    {
        base.UpdateData(scrollData);

        var data = scrollData as InventoryItemSlotData;

        ItemGradeImage.sprite = data.ItemGradeSprite;
        ItemIconImage.sprite = data.ItemIconSprite;
    }
}
