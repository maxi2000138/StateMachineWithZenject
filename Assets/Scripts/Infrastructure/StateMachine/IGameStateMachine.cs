
using Infrastructure.StateMachine.States.IStates;

namespace Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState>(string payload) where TState : class, IOverloadedState;
    }
}