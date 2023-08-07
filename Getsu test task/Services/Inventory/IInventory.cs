interface IInventory: IService
{
    void AddItem(InventoryItem item);
    List<InventoryItem> InventoryItems { get; }
}