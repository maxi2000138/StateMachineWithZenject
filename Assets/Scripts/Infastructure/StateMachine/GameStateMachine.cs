using System;
using System.Collections.Generic;
using Infastructure.StateMachine.States;
using Infastructure.StateMachine.States.IStates;

namespace Infastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState = null;

        public GameStateMachine(BootstrapState.Factory bootstrapFactory, GameState.Factory gameStateFactory)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = bootstrapFactory.Create(this),
                [typeof(GameState)] = gameStateFactory.Create(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            state.Enter();
            _currentState = state;
        }

        public void Enter<TState>(string sceneName) where TState : class, IOverloadedState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            state.Enter(sceneName);
            _currentState = state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}