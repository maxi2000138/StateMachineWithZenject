namespace Infrastructure.StateMachine.States.IStates
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}
