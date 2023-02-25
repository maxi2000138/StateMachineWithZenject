
using Infrastructure.StateMachine.States.IStates;

namespace Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IOverloadedState<TPayload>;
    }
}