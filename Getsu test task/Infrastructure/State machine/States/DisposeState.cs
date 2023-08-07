class DisposeState : IState
{
    public void Enter()
    {
        ServiceLocator.Dispose();
        Environment.Exit(0);
    }

    public void Exit()
    {
        
    }
}