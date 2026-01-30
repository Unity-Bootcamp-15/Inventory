using System;

public sealed class UserInventoryItem : Entity<long>
{
    public long SerialNumber => Id;
    public int ItemId { get; }

    private UserInventoryItem(long serialNumber, int itemId)
        : base(serialNumber)
    {
        ItemId = itemId;
    }

    public static UserInventoryItem Create(int itemId)
    {
        Random randomGenerator = new Random();
        long serialNumber = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + randomGenerator.Next(9999).ToString("D4"));
        
        return new UserInventoryItem(serialNumber, itemId);
    }
}