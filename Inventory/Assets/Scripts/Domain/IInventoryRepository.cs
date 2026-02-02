using ErrorOr;

public interface IInventoryRepository
{
    ErrorOr<Success> Save(Inventory inventory);
    ErrorOr<Inventory> Load();
}