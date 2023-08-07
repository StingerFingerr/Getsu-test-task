public struct InventoryItem
{
    public int ItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; }

    public InventoryItem()
    {
        ItemId = 0;
        Amount = 0;
        Name = string.Empty;
    }

    public override string ToString() =>
        $"Item: {Name} x{Amount}";
}