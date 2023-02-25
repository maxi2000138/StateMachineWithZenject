using Infrastructure.Services.SceneLoadService;
using Infrastructure.StateMachine.States.IStates;
using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : IOverloadedState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoadService _sceneLoadService;

        public BootstrapState(GameStateMachine stateMachine, ISceneLoadService sceneLoadService)
        {
            _stateMachine = stateMachine;
            _sceneLoadService = sceneLoadService;
        }

        public void Enter(string levelName) => 
            _sceneLoadService.LoadScene(levelName, EnterGameState);

        public void EnterGameState() => 
            _stateMachine.Enter<LoadLevelState>();

        public void Exit()
        {
            
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}