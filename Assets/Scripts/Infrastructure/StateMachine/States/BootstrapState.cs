namespace Infrastructure.StateMachine.States
{
    public class BootstrapState : StateBase
    {
        public override void OnEnter()
        {
            Game.EnterState<LoadLevelState>();
        }
    }
}