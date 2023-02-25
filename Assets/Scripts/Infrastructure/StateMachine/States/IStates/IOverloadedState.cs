namespace Infrastructure.StateMachine.States.IStates
{
    public interface IOverloadedState<TState> : IExitableState
    {
        void Enter(TState payload);
    }
}