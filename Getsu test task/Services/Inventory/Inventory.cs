class Inventory : IInventory
{
    public List<InventoryItem> InventoryItems { get; private set; }

    public Inventory() => 
        InventoryItems = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        var index = InventoryItems.FindIndex(i => i.ItemId == item.ItemId);
        if (index == -1)
            AddInNewSlot(item);
        else
            AddInExistingSlot(index, item);
    }

    private void AddInExistingSlot(int slot, InventoryItem item)
    {
        var existing = InventoryItems[slot];
        existing.Amount += item.Amount;
        InventoryItems[slot] = existing;
    }

    private void AddInNewSlot(InventoryItem item) => 
        InventoryItems.Add(item);
}