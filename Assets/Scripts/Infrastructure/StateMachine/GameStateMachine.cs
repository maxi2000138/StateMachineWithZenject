using System;
using System.Collections.Generic;
using Infrastructure.StateMachine.States.IStates;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, StateBase> _states = new();
        private StateBase _currentState = null;

        public GameStateMachine(IEnumerable<StateBase> states)
        {
            foreach (StateBase state in states) 
                AddState(state);
        }
        
        public void Enter<TState>(Game game) where TState : StateBase
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;
            state.Enter(game);
        }

        public void AddState(StateBase state)
        {
            _states.Add(state.GetType(), state);
        }

        public void RemoveState(Type stateType)
        {
            if (!_states.Remove(stateType))
                throw new ArgumentException($"Key '{stateType}' not found.");
        }

        private TState GetState<TState>() where TState : StateBase
        {
            Type stateType = typeof(TState);
            if (!_states.TryGetValue(stateType, out StateBase state))
                throw new ArgumentOutOfRangeException(nameof(TState), $"State '{stateType}' not found in states.");
            
            return state as TState;
        }
    }
}