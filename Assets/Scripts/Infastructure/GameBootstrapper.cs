using Infastructure.Configs;
using Infastructure.StateMachine;
using Infastructure.StateMachine.CoroutineRunner;
using Infastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Infastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    { 
        private GameStateMachine _stateMachine;
        private ScenesConfig _scenesConfig;

        [Inject]
        public void Construct(GameStateMachine stateMachine, ScenesConfig config)
        {
            _stateMachine = stateMachine;
            _scenesConfig = config;
        }

        private void Start()
        {
            _stateMachine.Enter<BootstrapState>(_scenesConfig.BootstrapSceneSettings.Name);
            DontDestroyOnLoad(this);
        }
    
    }
}