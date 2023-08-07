class InitializationState : IState
{
    public void Enter()
    {
        ServiceLocator.InitService<IJsonReader>(new  JsonFileReader());
        ServiceLocator.InitService<IStaticDataProvider>(new LocalJsonStaticDataProvider());
        ServiceLocator.InitService<IWindowManager>(new WindowManager());
        ServiceLocator.InitService<IInventory>(new Inventory());
        ServiceLocator.InitService<IInventoryItemsInfos>(new InventoryItemsInfos());
        ServiceLocator.InitService<ICaseManager>(new CaseManager());
    }

    public void Exit()
    {
        
    }
}