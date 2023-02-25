using Infrastructure.Configs;
using Infrastructure.Services.SceneLoadService;
using Unity.VisualScripting;
using Zenject;
using IState = Infrastructure.StateMachine.States.IStates.IState;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ScenesConfig _scenesConfig;
        private readonly ISceneLoadService _sceneLoadService;

        public BootstrapState(GameStateMachine stateMachine, ScenesConfig _scenesConfig)
        {
            _stateMachine = stateMachine;
            this._scenesConfig = _scenesConfig;
        }

        public void Enter()
        {
            _stateMachine.Enter<LoadLevelState, string>(_scenesConfig.GameSceneSettings.Name);
        }


        public void Exit()
        {
            
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}