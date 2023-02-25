using Infastructure.StateMachine.CoroutineRunner;
using Zenject;

namespace Infastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCoroutineRunner();
        }

        private void BindCoroutineRunner()
        {
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(ResoucePathes.CoroutineRunner).AsSingle();
        }
        
        
        
        
    }
}
