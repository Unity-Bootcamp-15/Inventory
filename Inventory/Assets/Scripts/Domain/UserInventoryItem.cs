using System;

public sealed class UserInventoryItem : Entity<long>
{
    public long SerialNumber => Id;
    public ItemId ItemId { get; }

    private UserInventoryItem(long serialNumber, ItemId itemId)
        : base(serialNumber)
    {
        ItemId = itemId;
    }

    public static UserInventoryItem Create(ItemId itemId)
    {
        Random randomGenerator = new Random();
        long serialNumber = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + randomGenerator.Next(9999).ToString("D4"));
        
        return new UserInventoryItem(serialNumber, itemId);
    }
}