using Infastructure.Services.SceneLoadService;
using Infastructure.StateMachine.States.IStates;
using Zenject;

namespace Infastructure.StateMachine.States
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
            _stateMachine.Enter<GameState>();

        public void Exit()
        {
            
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}