using Infrastructure.Configs;
using Infrastructure.Installers;
using Infrastructure.Services.SceneLoadService;
using Infrastructure.StateMachine.States.IStates;
using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class LoadLevelState : IState
    {
        private readonly ISceneLoadService _loadService;
        private readonly ScenesConfig _scenesConfig;
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(ISceneLoadService loadService, ScenesConfig scenesConfig, GameStateMachine stateMachine)
        {
            _loadService = loadService;
            _scenesConfig = scenesConfig;
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            _loadService.LoadScene(_scenesConfig.GameSceneSettings.Name, EnterGameState);
        }

        public void EnterGameState()
        {
            _stateMachine.Enter<GameState>();   
        }

        public void Exit()
        {
            
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
            
        }
    }
}