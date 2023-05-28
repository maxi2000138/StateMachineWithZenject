using Infrastructure;
using Infrastructure.Services.SceneLoadService;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.CoroutineRunner;
using Infrastructure.StateMachine.States;
using Infrastructure.StateMachine.States.IStates;
using Zenject;

namespace CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindSceneLoadService();
            BindStatesForStateMachine();
            BindGameStateMachine();

            Container.BindInterfacesAndSelfTo<Game>().AsSingle();
        }

        private void BindStatesForStateMachine()
        {
            Container.Bind<StateBase>()
                .To(
                    typeof(BootstrapState),
                    typeof(LoadLevelState)
                )
                .WhenInjectedInto<IGameStateMachine>();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }

        private void BindSceneLoadService() => 
            Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
        
        private void BindCoroutineRunner() =>
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(ResoucePathes.CoroutineRunner).AsSingle();
    }
}
