public class StateMachine
{
    private Dictionary<Type, IState> _states;
    private IState _currentState;

    public StateMachine()
    {
        _states = new Dictionary<Type, IState>()
        {
            {typeof(InitializationState), new InitializationState() }, 
            {typeof(InventoryState), new InventoryState(this) }, 
            {typeof(MenuState), new MenuState(this) }, 
            {typeof(OpenCasesState), new OpenCasesState(this) }, 
            {typeof(DisposeState), new DisposeState() }, 
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
        _currentState?.Exit();
        _currentState = GetState<TState>();
        _currentState.Enter();
    }

    private IState GetState<TState>() where TState : class, IState =>
        _states[typeof(TState)];

}