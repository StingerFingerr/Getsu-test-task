class MenuState : IState
{
    private List<WindowButton> _buttons;
    private StateMachine _stateMachine;
    private IWindowManager _windowManager;

    public MenuState(StateMachine stateMachine)
    {
        _buttons = new List<WindowButton>()
        {
            new WindowButton(){Id = 1, Name = "Open cases", OnClicked = OpenCases},
            new WindowButton(){Id = 2, Name = "Open inventory", OnClicked = OpenInventory},
            new WindowButton(){Id = 3, Name = "Exit", OnClicked = ExitApp}
        };
        _stateMachine = stateMachine;
    }

    

    public void Enter()
    {
        _windowManager ??= ServiceLocator.GetService<IWindowManager>();

        _windowManager.Show(_buttons);
    }

    public void Exit()
    {
        
    }

    private void OpenCases() => 
        _stateMachine.Enter<OpenCasesState>();

    private void OpenInventory() => 
        _stateMachine.Enter<InventoryState>();

    private void ExitApp() => 
        _stateMachine.Enter<DisposeState>();
}
