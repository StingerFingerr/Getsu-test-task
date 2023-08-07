class OpenCasesState : IState
{
    private List<WindowButton> _selectCaseButtons;
    private List<WindowButton> _showCaseDropButtons;
    private StateMachine _stateMachine;
    private IWindowManager _windowManager;
    private IInventory _inventory;
    private ICaseManager _caseManager;

    public OpenCasesState(StateMachine stateMachine)
    {
        _selectCaseButtons = new List<WindowButton>()
        {
            new WindowButton(){Id = 1, Name = "Open case 1", OnClicked = () => { OpenCase(0); } },
            new WindowButton(){Id = 2, Name = "Open case 2", OnClicked = () => { OpenCase(1); } },
            new WindowButton(){Id = 3, Name = "Open case 3", OnClicked = () => { OpenCase(2); } },
            new WindowButton(){Id = 4, Name = "Back to menu", OnClicked = BackToMenu}
        };
        _showCaseDropButtons = new List<WindowButton>()
        {
            new WindowButton(){Id = 1, Name = "Continue", OnClicked = Continue}
        };
        _stateMachine = stateMachine;
    } 

    public void Enter()
    {
        _windowManager ??= ServiceLocator.GetService<IWindowManager>();
        _inventory ??= ServiceLocator.GetService<IInventory>();
        _caseManager ??= ServiceLocator.GetService<ICaseManager>();

        Continue();
    }

    public void Exit()
    {
        
    }

    private void Continue() => 
        _windowManager.Show(_selectCaseButtons);

    private void BackToMenu() => 
        _stateMachine.Enter<MenuState>();

    private void OpenCase(int caseIndex)
    {
        var newItem = _caseManager.OpenCase(caseIndex);

        _inventory.AddItem(newItem);

        _windowManager.Show(_showCaseDropButtons, $"You earn: {newItem}");
    }
}