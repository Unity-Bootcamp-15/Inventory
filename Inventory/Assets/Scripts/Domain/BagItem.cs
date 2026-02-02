using System;

public sealed class BagItem : Entity<long>
{
    public long SerialNumber => Id;
    public ItemId ItemId { get; }

    private BagItem(long serialNumber, ItemId itemId)
        : base(serialNumber)
    {
        ItemId = itemId;
    }

    public static BagItem Create(ItemId itemId)
    {
        Random randomGenerator = new Random();
        long serialNumber = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + randomGenerator.Next(9999).ToString("D4"));
        
        return new BagItem(serialNumber, itemId);
    }
}