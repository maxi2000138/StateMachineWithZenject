namespace Infrastructure.StateMachine.States.IStates
{
    public interface IOverloadedState : IExitableState
    {
        void Enter(string payload);
    }
}