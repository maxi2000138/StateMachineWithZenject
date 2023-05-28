using Infrastructure.Configs;
using Infrastructure.Installers;
using Infrastructure.Services.SceneLoadService;

namespace Infrastructure.StateMachine.States
{
    public class LoadLevelState : StateBase
    {
        private readonly ISceneLoadService _loadService;
        private readonly ScenesConfig _scenesConfig;

        public LoadLevelState(ISceneLoadService loadService, ScenesConfig scenesConfig)
        {
            _scenesConfig = scenesConfig;
            _loadService = loadService;
        }
        
        public override void OnEnter()
        {
            _loadService.LoadScene(_scenesConfig.GameSceneSettings.Name, EnterGameState);
        }

        private void EnterGameState() => 
            Game.EnterState<GameState>();
    }
}