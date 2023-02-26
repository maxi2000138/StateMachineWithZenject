using Infrastructure.Installers;
using Infrastructure.Services.SceneLoadService;
using Infrastructure.StateMachine.States.IStates;
using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class LoadLevelState : IOverloadedState<string>
    {
        private readonly ISceneLoadService _loadService;
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(ISceneLoadService loadService, GameStateMachine stateMachine)
        {
            _loadService = loadService;
            _stateMachine = stateMachine;
        }
        
        public void Enter(string sceneName)
        {
            _loadService.LoadScene(sceneName, EnterGameState);
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