
using System;
using Infrastructure.StateMachine.States.IStates;

namespace Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>(Game game) where TState : StateBase;
        void AddState(StateBase state);
        void RemoveState(Type stateType);
    }
}