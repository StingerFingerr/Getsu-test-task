class InventoryState : IState
{
    private List<WindowButton> _buttons;
    private StateMachine _stateMachine;

    private IWindowManager _windowManager;
    private IInventory _inventory;

    public InventoryState(StateMachine stateMachine)
    {
        _buttons = new List<WindowButton>()
        {
            new WindowButton(){Id = 1, Name = "Back to menu", OnClicked = BackToMenu}
        };
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _windowManager ??= ServiceLocator.GetService<IWindowManager>();
        _inventory ??= ServiceLocator.GetService<IInventory>();

        _windowManager.Show(_buttons, _inventory.InventoryItems);
    }

    public void Exit()
    {
        
    }

    private void BackToMenu() => 
        _stateMachine.Enter<MenuState>();
}