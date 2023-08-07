class Program
{
    static void Main()
    {
        var stateMachine = new StateMachine();

        stateMachine.Enter<InitializationState>();
        stateMachine.Enter<MenuState>();
    }
}