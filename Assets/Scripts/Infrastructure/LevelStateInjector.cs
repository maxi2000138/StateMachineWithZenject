using System;using System.Collections.Generic;
using Infrastructure.StateMachine;
using Zenject;

public class LevelStateInjector : IInitializable, IDisposable
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly IEnumerable<StateBase> _states;

    public LevelStateInjector(IGameStateMachine gameStateMachine, IEnumerable<StateBase> states)
    {
        _gameStateMachine = gameStateMachine;
        _states = states;
    }

    public void Initialize()
    {
        foreach (StateBase state in _states)
            _gameStateMachine.AddState(state);
    }

    public void Dispose()
    {
        foreach (StateBase state in _states)
            _gameStateMachine.RemoveState(state.GetType());
    }
}
