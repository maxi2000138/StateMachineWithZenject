using Infrastructure.StateMachine.States.IStates;

public abstract class StateBase
{
    protected Game Game;
    public void Enter(Game game)
    {
        Game = game;
        OnEnter();
    }
    
    public virtual void OnEnter() { }
    public virtual void Exit() { }
}
