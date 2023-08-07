class LocalJsonStaticDataProvider : IStaticDataProvider
{
    private List<List<CaseItemDropChance>> _casesDropChances;

    private IJsonReader _jsonReader;

    public LocalJsonStaticDataProvider()
    {
        _jsonReader = ServiceLocator.GetService<IJsonReader>();

        if (_jsonReader.JsonExists(PathesProvider.STATIC_DATA_PATH))
            _casesDropChances = _jsonReader.Read<List<List<CaseItemDropChance>>>(PathesProvider.STATIC_DATA_PATH);
        else
            _casesDropChances = CreateDefaultDropChances();
    }

    private List<List<CaseItemDropChance>> CreateDefaultDropChances()
    {
        var defaulCaseChances = new List<CaseItemDropChance>()
        {
            new CaseItemDropChance(){ItemId = 0, NormalizedChance = .5f, MinAmount = 10, MaxAmount = 100},
            new CaseItemDropChance(){ItemId = 1, NormalizedChance = .2f, MinAmount = 1, MaxAmount = 2},
            new CaseItemDropChance(){ItemId = 2, NormalizedChance = .2f, MinAmount = 1, MaxAmount = 2},
            new CaseItemDropChance(){ItemId = 3, NormalizedChance = .1f, MinAmount = 1, MaxAmount = 1},
            new CaseItemDropChance(){ItemId = 4, NormalizedChance = .1f, MinAmount = 5, MaxAmount = 7},
            new CaseItemDropChance(){ItemId = 5, NormalizedChance = 1f, MinAmount = 100, MaxAmount = 200}
        };
        var defaultChances = new List<List<CaseItemDropChance>> 
        { 
            defaulCaseChances,
            defaulCaseChances,
            defaulCaseChances,
        };
        _jsonReader.Write<List<List<CaseItemDropChance>>>(PathesProvider.STATIC_DATA_PATH, defaultChances);
        return defaultChances;
    }

    public List<CaseItemDropChance> GetCaseChances(int caseIndex) =>
        _casesDropChances[caseIndex];
}