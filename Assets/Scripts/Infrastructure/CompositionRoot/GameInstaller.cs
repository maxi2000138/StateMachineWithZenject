using Infrastructure;
using Infrastructure.Installers;
using Infrastructure.Services.SceneLoadService;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.CoroutineRunner;
using Zenject;

namespace CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindGameStateMachine();
            BindGameBootstrapperFactory();
            BindSceneLoadService();
        }

        private void BindSceneLoadService() => 
            Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
        
        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>()
                .FromSubContainerResolve().ByInstaller<GameStateMachineInstaller>().AsSingle();
        }

        private void BindGameBootstrapperFactory() => 
            Container.BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
                .FromComponentInNewPrefabResource(ResoucePathes.BootstrapPrefab);
        
        private void BindCoroutineRunner() =>
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(ResoucePathes.CoroutineRunner).AsSingle();
    }
}
