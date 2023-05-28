namespace Infrastructure.StateMachine.States.IStates
{
    public interface IGame
    {
        void Restart();
        void EnterState<TState>() where TState : StateBase;
    }
}