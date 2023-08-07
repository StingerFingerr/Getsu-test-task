interface IStaticDataProvider : IService
{
    List<CaseItemDropChance> GetCaseChances(int caseIndex);
}