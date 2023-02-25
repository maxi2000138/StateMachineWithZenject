using Infastructure.Configs;
using Infastructure.Services.SceneLoadService;
using Infastructure.StateMachine.States.IStates;
using Zenject;

namespace Infastructure.StateMachine.States
{
    public class GameState : IState
    {
        private readonly ISceneLoadService _loadService;
        private readonly ScenesConfig _scenesConfig;

        public GameState(ISceneLoadService loadService, ScenesConfig scenesConfig)
        {
            _loadService = loadService;
            _scenesConfig = scenesConfig;
        }
        
        public void Enter()
        {
            _loadService.LoadScene(_scenesConfig.GameSceneSettings.Name);
        }

        public void Exit()
        {
            
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, GameState>
        {
            
        }
    }
}