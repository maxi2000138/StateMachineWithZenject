using System;
using System.Collections.Generic;
using Infrastructure.Installers;
using Infrastructure.StateMachine.States;
using Infrastructure.StateMachine.States.IStates;
using Zenject;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState = null;

        public GameStateMachine(BootstrapState.Factory bootstrapFactory, 
            LoadLevelState.Factory loadLevelFactory, GameState.Factory gameStateFactory)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = bootstrapFactory.Create(this),
                [typeof(LoadLevelState)] = loadLevelFactory.Create(this),
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

        public void Enter<TState,TOverload>(TOverload sceneName) where TState : class, IOverloadedState<TOverload>
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            state.Enter(sceneName);
            _currentState = state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
        
        
        public class Factory : PlaceholderFactory<GameStateMachine>
        {
        }
    }
}