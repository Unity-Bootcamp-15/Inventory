using System;
using UnityEngine.Assertions;

public enum ItemGrade
{
    None,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public enum ItemType
{
    None,
    Weapon,
    Shield,
    ChestArmor,
    Gloves,
    Boots,
    Accessary
}

public readonly struct ItemId : IEquatable<ItemId>
{
    public readonly int RawId;
    public readonly ItemGrade Grade;
    public readonly ItemType Type;
    public readonly int Index;

    public ItemId(int id)
    {
        Assert.IsTrue(id.ToString().Length == 5);
        int gradeDigit = id / 1000 % 10;
        Assert.IsTrue(Enum.IsDefined(typeof(ItemGrade), gradeDigit));
        int typeDigit = id / 10000;
        Assert.IsTrue(Enum.IsDefined(typeof(ItemType), typeDigit));

        RawId = id;
        Grade = (ItemGrade)gradeDigit;
        Type = (ItemType)typeDigit;
        Index = id % 1000;
    }

    public bool Equals(ItemId other)
    {
        return RawId == other.RawId;
    }
}

public sealed class Item : Entity<ItemId>
{
    public string Name { get; }
    public Status Stat { get; }

    public Item(int id, string name, Status stat)
        : base(new ItemId(id))
    {
        Name = name;
        Stat = stat;
    }
}