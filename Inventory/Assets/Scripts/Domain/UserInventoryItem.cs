public sealed class UserInventoryItem : Entity<long>
{
    public long SerialNumber => Id;
    public int ItemId { get; }

    public UserInventoryItem(long serialNumber, int itemId)
        : base(serialNumber)
    {
        ItemId = itemId;
    }
}