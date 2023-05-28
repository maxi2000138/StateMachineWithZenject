using Infrastructure.Installers;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        AddLevelStates();
    }

    private void AddLevelStates()
    {
        Container.Bind<StateBase>()
            .To(
                typeof(GameState)
            )
            .WhenInjectedInto<LevelStateInjector>();
        Container.BindInterfacesTo<LevelStateInjector>().AsSingle();
    }
}