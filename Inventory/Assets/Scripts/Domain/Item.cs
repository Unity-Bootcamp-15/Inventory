public sealed class Item : Entity<int>
{
    // Id, Name, Atk, Def

    public string Name { get; }
    public Status Stat { get; }

    public Item(int id, string name, Status stat)
        : base(id)
    {
        Name = name;
        Stat = stat;
    }
}