using System;

[Serializable]
public sealed class ItemModel
{
    public int item_id;
    public string item_name;
    public int attack_power;
    public int defense;
}

[Serializable]
public sealed class ItemModels
{
    public ItemModel[] data;
}