class InventoryItemsInfos : IInventoryItemsInfos
{
    private List<InventoryItem> _items;

    public InventoryItemsInfos()
    {
        _items = new List<InventoryItem>()
        {
            new InventoryItem() {ItemId = 0, Name = "Coins"},
            new InventoryItem() {ItemId = 1, Name = "Health potion"},
            new InventoryItem() {ItemId = 2, Name = "Mana potion"},
            new InventoryItem() {ItemId = 3, Name = "Sword"},
            new InventoryItem() {ItemId = 4, Name = "Ring"},
            new InventoryItem() {ItemId = 5, Name = "Exp"},
        };
    }

    public InventoryItem GetItem(int itemId) =>
        _items.First(x => x.ItemId == itemId);
}