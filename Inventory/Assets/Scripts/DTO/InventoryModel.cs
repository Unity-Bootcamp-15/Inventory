using System;
using System.Collections.Generic;

[Serializable]
public sealed class BagItemModel
{
    public long serial_number;
    public int item_id;
}

[Serializable]
public sealed class InventoryModel
{
    public BagItemModel[] data;
}