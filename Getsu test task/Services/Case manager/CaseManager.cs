class CaseManager : ICaseManager
{
    private IStaticDataProvider _staticDataProvider;
    private IInventoryItemsInfos _inventoryItemsInfos;

    private Random _random;

    public CaseManager()
    {
        _staticDataProvider = ServiceLocator.GetService<IStaticDataProvider>();
        _inventoryItemsInfos = ServiceLocator.GetService<IInventoryItemsInfos>();
        _random = new Random();
    }

    public InventoryItem OpenCase(int caseIndex)
    {
        var chances = _staticDataProvider.GetCaseChances(caseIndex);
        var itemChance = GetRandomItem(chances);
        var newItem = _inventoryItemsInfos.GetItem(itemChance.ItemId);
        newItem.Amount = GetRandomAmount(itemChance);
        return newItem;
    }

    private int GetRandomAmount(CaseItemDropChance itemChance) =>
        _random.Next(itemChance.MinAmount, itemChance.MaxAmount);

    private CaseItemDropChance GetRandomItem(List<CaseItemDropChance> chances)
    {
        foreach (var chance in chances)
        {
            if(_random.NextDouble() <= chance.NormalizedChance)
                return chance;
        }
        return chances.First();
    }
}