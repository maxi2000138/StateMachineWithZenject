using Infrastructure.Configs;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.CoroutineRunner;
using Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    { 
        private IGameStateMachine _stateMachine;
        private ScenesConfig _scenesConfig;

        [Inject]
        public void Construct(IGameStateMachine stateMachine, ScenesConfig config)
        {
            _stateMachine = stateMachine;
            _scenesConfig = config;
        }

        private void Start()
        {
            _stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }

        public class Factory : PlaceholderFactory<GameBootstrapper>
        {
        }

    }
}